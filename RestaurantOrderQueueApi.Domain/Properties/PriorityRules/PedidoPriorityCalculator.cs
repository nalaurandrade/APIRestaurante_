namespace RestaurantOrderQueueApi.Domain.PriorityRules;

public static class PedidoPriorityCalculator
{
    public static int Calcular(
        bool clientePrioritario,
        bool delivery,
        int tempoPreparo)
    {
        int prioridade = 0;

        if (clientePrioritario)
            prioridade += 50;

        if (delivery)
            prioridade += 30;

        prioridade += tempoPreparo;

        return prioridade;
    }
}