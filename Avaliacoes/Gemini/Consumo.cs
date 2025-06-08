using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
namespace Avaliacoes.Gemini
{
    public class Api
        {
            public static async Task<string> Prompt() //aqui estamos criando uma função assíncrona para que mesmo enquanto essa função não obter a resposta do meio externo, o programa funcione normalmente
            {
                //aqui temos os requisitos para que a api funcione, no caso a key e a url para gerar texto
                string ChaveApi = "AIzaSyD_UANCLhRZkW_5y7vLx9h_GBL7Gjd1BBQ";
                string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=AIzaSyD_UANCLhRZkW_5y7vLx9h_GBL7Gjd1BBQ";

                //depois, com base na estrutura do json fornecido pela própria documentação criaremos o prompty a ser enviado, no caso são elas: contents, parts e text
                string texto = "Vou te mandar algumas avaliações de um monitor, analise e faça um unico texto resumindo o que o público acha desse monitor:" +
                    "Um bom monitor, de fato vale o custo benefício.\n comprei" +
                    "e acho que não irei me arrepender, surpreendeu minhas espectativas.\n não sei foi um bom investimento, a tela começou a piscar com apenas 2 meses de uso.";

                var json = $@"{{""contents"": [{{""parts"": [{{""text"": ""{texto}""}}]}}]}}";

                HttpClient client = new HttpClient();
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var resposta = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(resposta);
                var respostaFinal = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

                return respostaFinal;
                
                
            }
        }

    
}
