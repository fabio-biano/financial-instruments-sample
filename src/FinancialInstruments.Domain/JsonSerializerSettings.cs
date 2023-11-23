namespace FinancialInstruments.Domain;

public static class JsonSerializerSettings
{
    public static JsonSerializerOptions JsonSerializerOptions
    {
        get
        {
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.AddJsonSerializerOptions();

            return jsonSerializerOptions;
        }
    }
    public static JsonSerializerOptions AddJsonSerializerOptions(this JsonSerializerOptions jsonSerializerOptions)
    {
        jsonSerializerOptions.PropertyNameCaseInsensitive = true;
        jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        jsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        return jsonSerializerOptions;
    }
}