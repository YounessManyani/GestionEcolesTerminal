using MySql.Data.MySqlClient;
namespace GestionDeProjet;

public class Database
{
    private MySqlConnection conn;

    public Database()
    {
        string connStr = "server=localhost;user=root;database=gestion_notes;port=3306;password=root";
        conn = new MySqlConnection(connStr);
    }
    public void OpenConnection()
    {
        try
        {
            conn.Open();
            Console.WriteLine("Connexion réussie à la base de données.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur de connexion: " + ex.Message);
        }
    }
    public void CloseConnection()
    {
        if (conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("Connexion fermée.");
        }
    }
    //Ajouter des étudiants dans la database
    public void InsertEtudiant(Étudiant etudiant)
    {
        string query = "INSERT INTO Etudiants (Nom, Prenom) VALUES (@nom, @prenom)";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@nom", etudiant.nom);
            cmd.Parameters.AddWithValue("@prenom", etudiant.prenom);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Étudiant {etudiant.nom} {etudiant.prenom} inséré dans la base de données.");
        }
    }
    //Ajouter des Profs dans la database

    public void InsertProf(Professeur professeur)
    {
        string query = "INSERT INTO Professeur (nom, prenom) VALUES (@nom, @prenom)";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@nom", professeur.nom);
            cmd.Parameters.AddWithValue("@prenom", professeur.prenom);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Professeur {professeur.nom} {professeur.prenom} inséré dans la base de données.");
        }
    }
    //Ajouter Matier et Coeff dans la dataase

    public void InsertMatiere(Matière matiere)
    {
        string query = "INSERT INTO Matière (NomMatiere, coefMatiere) VALUES (@NomMatiere, @coefMatiere)";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@NomMatiere", matiere.NomMatiere);
            cmd.Parameters.AddWithValue("@coefMatiere", matiere.coefMatiere);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Matiere {matiere.NomMatiere} {matiere.coefMatiere} inséré dans la base de données");
        }
    }
    
    //methode pour checker  le login
    public bool CheckLogin(string nomUtilisateur, string motDePasse)
    {
        string query = "SELECT COUNT(*) FROM Utilisateurs WHERE NomUtilisateur = @nom AND MotDePasse = @motdepasse";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@nom", nomUtilisateur);
            cmd.Parameters.AddWithValue("@motdepasse", motDePasse);
            
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }
    // Méthode pour sélectionner un étudiant par nom
    public int GetEtudiantId(string nom, string prenom)
    {
        string query = "SELECT Id FROM Etudiants WHERE Nom = @nom AND Prenom = @prenom";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            var result = cmd.ExecuteScalar();

            // Si l'étudiant existe, retourner son ID
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return -1; // Retourne -1 si l'étudiant n'existe pas
            }
        }
    }
    // Méthode pour ajouter une note
    public void AjouterNote(int etudiantId, string matiere, double note)
    {
        string query = "INSERT INTO Notes (EtudiantId, Matiere, Note) VALUES (@etudiantId, @matiere, @note)";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@etudiantId", etudiantId);
            cmd.Parameters.AddWithValue("@matiere", matiere);
            cmd.Parameters.AddWithValue("@note", note);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Note ajoutée pour l'étudiant avec ID {etudiantId}.");
        }
    }
}