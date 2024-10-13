namespace GestionDeProjet;

public class Étudiant
{
    public string nom { get; set; }
    public string prenom { get; set; }
    public string id { get; set; }
    public Dictionary<string, List<double>> NotesParMatiére { get; set; } = new Dictionary<string, List<double>>();
    

    public double CalculerMoyenne()
    {
        var tousLesNotes = NotesParMatiére.Values.SelectMany(notes => notes);
        return tousLesNotes.Any() ? tousLesNotes.Average() : 0; ;
    }
    

    
}