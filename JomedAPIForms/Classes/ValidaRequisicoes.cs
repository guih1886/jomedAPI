using Newtonsoft.Json.Linq;

namespace JomedAPIForms.Classes;

public static class ValidaRequisicoes
{
    public static async Task<string> ValidaLoginReq(HttpResponseMessage resposta)
    {
        string msg = await resposta.Content.ReadAsStringAsync();
        if (msg.Contains("E-mail não pode estar vazio.")) return "E-mail não pode estar vazio.";
        if (msg.Contains("E-mail inválido.")) return "E-mail inválido.";
        if (msg.Contains("Senha não pode estar vazio.")) return "Senha não pode estar vazio.";
        if (msg.Contains("Usuário não encontrado.")) return "E-mail não cadastrado.";
        if (msg.Contains("Senha incorreta.")) return "Senha inválida.";
        return "Ok";
    }

    public static async Task<string> ValidaCadastroUsuarioReq(HttpResponseMessage resposta)
    {
        string msg = await resposta.Content.ReadAsStringAsync();
        if (msg.Contains("O e-mail deve ser informado.")) return "O e-mail deve ser informado.";
        if (msg.Contains("E-mail inválido.")) return "E-mail inválido.";
        if (msg.Contains("A senha deve ser informada.")) return "A senha deve ser informada.";
        if (msg.Contains("A confirmação de senha deve ser informada.")) return "A confirmação de senha deve ser informada.";
        if (msg.Contains("As senhas não são iguais.")) return "As senhas não são iguais.";
        if (msg.Contains("Usuário já cadastrado.")) return "Usuário já cadastrado.";
        return "Ok";
    }

    public static async Task<string> ValidaCadastroPacienteReq(HttpResponseMessage resposta)
    {
        string msg = await resposta.Content.ReadAsStringAsync();
        if (msg.Contains("O CPF não pode estar vazio.")) return "O CPF não pode estar vazio.";
        if (msg.Contains("O nome não pode estar vazio.")) return "O nome não pode estar vazio.";
        if (msg.Contains("O e-mail não pode estar vazio.")) return "O e-mail não pode estar vazio.";
        if (msg.Contains("A confirmação de senha deve ser informada.")) return "A confirmação de senha deve ser informada.";
        if (msg.Contains("As senhas não são iguais.")) return "As senhas não são iguais.";
        if (msg.Contains("Usuário já cadastrado.")) return "Usuário já cadastrado.";
        return "Ok";

    }

    public static async void Teste(HttpResponseMessage resposta)
    {
        string json = await resposta.Content.ReadAsStringAsync();
        // Parse JSON
        JObject parsedData = JObject.Parse(json);
        // Obter o objeto de erros
        JObject? errors = parsedData["errors"] as JObject;

        // Iterar sobre os erros e mostrar cada um em uma MessageBox
        if (errors != null)
        {
            List<string> lista = new List<string>();
            foreach (KeyValuePair<string, JToken?> error in errors)
            {
                string fieldName = error.Key;
                var errorsArray = error.Value as JArray;
                string errorMessage = $"{fieldName}: {errorsArray[0]}";
                lista.Add(errorMessage);
            }
            MessageBox.Show(lista[0], "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
