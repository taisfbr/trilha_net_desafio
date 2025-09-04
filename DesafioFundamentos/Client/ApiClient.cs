using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;

namespace DesafioFundamentos.Client;

public class VehicleData
{
    public string? Description { get; set; }
}

public static class ApiClient
{
    private static readonly HttpClient Client = new HttpClient();
    
    
    
    public static async Task<string?> ConsultarPlaca(string placa)
    {
        
        // NENHUM dado pessoal do dono do veículo é coletado.
        // NENHUM dado sensível é coletado ou usado nessa API.
        string apiUrl = "https://www.regcheck.org.uk/api/reg.asmx";
        
        // Esse é um username com 10 usos na API.
        // Caso o username tenha expirado, registre-se em https://www.placaapi.com.
        string? username = "user075";
        
        string soapBody = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <CheckBrazil xmlns=""http://regcheck.org.uk"">
      <RegistrationNumber>{placa}</RegistrationNumber>
      <username>{username}</username>
    </CheckBrazil>
  </soap:Body>
</soap:Envelope>";
        
        Client.DefaultRequestHeaders.Add("SOAPAction", "http://regcheck.org.uk/CheckBrazil");
        var httpContent = new StringContent(soapBody, Encoding.UTF8, "text/xml");

        try
        {
            var response = await Client.PostAsync(apiUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                XDocument xmlDoc = XDocument.Parse(responseContent);
                XNamespace ns = "http://regcheck.org.uk";
                var vehicleJsonElement = xmlDoc.Descendants(ns + "vehicleJson").FirstOrDefault();

                if (vehicleJsonElement != null)
                {
                    string vehicleJson = vehicleJsonElement.Value;
                    var veiculo = JsonSerializer.Deserialize<VehicleData>(vehicleJson);
                    return veiculo?.Description;
                }
            }
        }
      
        catch (HttpRequestException)
        {
            throw new HttpRequestException("Erro ao consultar a API");
        }
        catch (System.Xml.XmlException)
        {
            throw new System.Xml.XmlException("Erro ao parsear o XML");
        }
        catch (JsonException)
        {
            throw new JsonException("Erro ao parsear o JSON");
        }
        
        return null;
    }
}