namespace CleanArchitectureNetCore.Api.Errors
{
  public class CodeErrorResponse
  {
    public int StatusCode { get; set; }
    public string? Message { get; set; } = string.Empty;

    public CodeErrorResponse(int statusCode, string? message = null)
    {
      StatusCode = statusCode;
      Message = message ?? GetDefaultStatusCode(StatusCode);
    }

    private string GetDefaultStatusCode(int statusCode)
    {
      return statusCode switch
      {
        400 => "El Request enviado tiene errores",
        401 => "No tienes autorización para este recurso",
        404 => "No se encontro el recurso solicitado",
        500 => "Se producieron errores en el servidor",
        _ => string.Empty,
      };
    }
  }
}
