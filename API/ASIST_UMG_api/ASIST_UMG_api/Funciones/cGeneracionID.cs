namespace ASIST_UMG_api.Funciones
{
    public class cGeneracionID
    {
        
          public static int cGeneraID()
            {
                var guid = Guid.NewGuid();
                var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());            
                return int.Parse(justNumbers.Substring(0, 4));
            }
        
    }
}
