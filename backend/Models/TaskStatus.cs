namespace Backend.Models;

public static class TaskValues
{
  public const string A_Fazer = "A Fazer";
  public const string Em_Andamento = "Em Andamento";
  public const string Concluido = "Concluído";

  public static readonly string[] All =
  [
    A_Fazer,
    Em_Andamento,
    Concluido
  ];

}