using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                //httpstatus code
                case 200:
                    return "A requisicao feita foi um sucesso!";
                case 204:
                    return "A atualizacao foi efetuada com sucesso!";
                case 400:
                    return "Requisição está com uma sintaxe inválida.";
                case 401:
                    return "Não autorizado (não autenticado)";
                case 404:
                    return "Recurso não encontrado";
                case 405:
                    return "Método não permitido";
                case 500:
                    return "Um erro não tratado ocorreu no request";
                default:
                    return null;
            }
        }
    }
}
