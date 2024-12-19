namespace CA_1219
{
    public class Author
    {
        private string firstname;
        private string lastname;

        public string Firstname
        {
            get => firstname;
            set
            {
                if (value.Length < 3 || value.Length > 32)
                    throw new Exception("invalid firstname");
                firstname = value;
            }
        }
        public string Lastname
        {
            get => lastname;
            set
            {
                if (value.Length < 3 || value.Length > 32)
                    throw new Exception("invalid lastname");
                lastname = value;
            }
        }

        public Guid Guid { get; set; }

        public Author(string fullName)
        {
            string[] names = fullName.Split(' ');
            if (names.Length != 2)
                throw new ArgumentException("Invalid full name format");

            Firstname = names[0];
            Lastname = names[1];
            Guid = Guid.NewGuid();
        }
    }
}