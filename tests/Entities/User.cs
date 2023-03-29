
namespace DigitalLeaf.tests.Entities
{
    /// <summary>
    /// User Object
    /// </summary>
    public class User
    {
        public string Email;
        public string FirstName;
        public string LastName;
        public string Password;

        /// <summary>
        /// Constructor that builds a unique user object
        /// with the use of a random string.
        /// </summary>
        public User(string FirstName, string LastName)
        {
            string TimestampString = GenerateTimestampString();
            this.Email = FirstName + LastName + TimestampString + "@gmail.com";
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = "password";
            PrintOut();
        }

        /// <summary>
        /// Constructor that builds a user object with a specific email
        /// </summary>
        public User(string FirstName, string LastName, string Email)
        {
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = "password";
            PrintOut();
        }

        /// <summary>
        /// A method that prints to screen the important user information.
        /// </summary>
        public void PrintOut()
        {
            Console.WriteLine("Student First Name: " + this.FirstName);
            Console.WriteLine("Student Last Name: " + this.LastName);
            Console.WriteLine("Student Email: " + this.Email);
            Console.WriteLine("Password: " + this.Password);
        }

        /// <summary>
        /// Generates a timestamp string for the current time. Can be used for creating new/unique items
        /// </summary>
        /// <returns>timestamp as string</returns>
        public static string GenerateTimestampString()
        {
            return DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace(":", "");
        }
    }
}