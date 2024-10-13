// See https://aka.ms/new-console-template for more information

using GestionDeProjet;

class Program
{
    static void Main(string[] args)
    {
       
        
        // Créer une instance de Database
       Database db = new Database(); 
       db.OpenConnection();
       
       // Créer une instance de gestion
       GestionAjoute gestion = new GestionAjoute(db);
       gestion.DemanderInformations();

       foreach (var etudiant in gestion.etudiants)
       {
           Console.WriteLine($"Moyenne de {etudiant.nom} : {etudiant.CalculerMoyenne()}");
       }
       
       // Fermer la connexion après avoir terminé les opérations
       db.CloseConnection();
       
       
       

    }
}