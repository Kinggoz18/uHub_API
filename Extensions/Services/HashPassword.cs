using System.Security.Cryptography;
using System.Text;

namespace uHubAPI.Extensions.Services
{
	/// <summary>
	/// Utility class to hash an app users password 
	/// </summary>
	public class HashPassword
	{
		public static string HashUserPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
				try
				{
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
				catch(Exception ex)
				{
					throw new Exception(ex.Message);
				}

            }
		}
	}
}

