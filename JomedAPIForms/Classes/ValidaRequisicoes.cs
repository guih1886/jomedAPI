using Newtonsoft.Json.Linq;

namespace JomedAPIForms.Classes;

public static class ValidaRequisicoes
{
    public static async Task<string> ValidarErrosRequisicao(HttpResponseMessage resposta)
    {
        string json = await resposta.Content.ReadAsStringAsync();
        if (json.Contains("errors"))
        {
            // Parse JSON
            JObject convertido = JObject.Parse(json);
            // Obter o objeto de erros
            JObject? errors = convertido["errors"] as JObject;
            // Iterar sobre os erros e mostrar cada um em uma MessageBox
            if (errors != null)
            {
                List<string> lista = new List<string>();
                foreach (var error in errors)
                {
                    var erro = error.Value as JArray;
                    lista.Add(erro![0].ToString());
                }
                return lista[0];
            }
            return "";
        }
        return json;
    }
}
