namespace TheMovie.Models
{
    // Interface til de model-typer, som vores DataHandler skal kunne håndtere - Altså de typer, vi gerne vil kunne gemme i csv-filer.
    // For disse typer er det nødvendigt med en ToString()-metode, da SaveDataFile() i DataHandler-klassen afhænger af denne metode.
    public interface IEntity
    {
        public string ToString();
    }
}
