namespace GrupoA.Education.Student.Infra.Data.DataDefinitions
{
    public class DatabaseTypes
    {
        public static readonly string Integer = "integer";        
        public static readonly string Boolean = "boolean";
        public static readonly string Date = "timestamp with time zone";
        public static readonly string Uuid = "uuid";
        public static string String(int length = 255)
        {
            if (length <= 0)
                length = 255;

            return $"varchar({length})";
        }
    
    }
}