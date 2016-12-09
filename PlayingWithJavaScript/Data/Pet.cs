namespace Data
{
    public class Pet
    {
        public string Name { get; set; }
        public PetType PetType { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Name, PetType);
        }
    }
}
