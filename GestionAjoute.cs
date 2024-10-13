namespace GestionDeProjet;
using System.Collections.Generic;
using System.Linq;

public class GestionAjoute 
{
    
    private Database db;

    public GestionAjoute(Database database)
    {
        db = database;
    }
    
    
    public List<Étudiant> etudiants = new List<Étudiant>();
    public List<Professeur> professeurs = new List<Professeur>();
    public List<Matière> matières = new List<Matière>();
    public List<Absence> absences = new List<Absence>();
    public List<Retard> retards = new List<Retard>();
    public void AjouterEtudiant(Étudiant etudiant)
    {
        etudiants.Add(etudiant);
        Console.WriteLine($"Étudiant {etudiant.nom} et {etudiant.prenom} ajouté.");
    }

    public void AjouterProfesseur(Professeur professeur)
    {
        professeurs.Add(professeur);
        Console.WriteLine($"Professeur {professeur.nom} et {professeur.prenom} ajouté.");
    }

    public void AjouterMatiere(Matière matiere)
    {
        matières.Add(matiere);
        Console.WriteLine($"Matiere {matiere.NomMatiere} avec coeficient {matiere.coefMatiere} ajouté.");
    }

    public void AjouterAbsence(Absence absence , Étudiant etudiant)
    {
        absences.Add(absence);
        Console.WriteLine($"{etudiant.nom} a : {absence.NbAbsence} absence  ");
    }

    public void AjouterRetard(Retard retard, Étudiant etudiant)
    {
        retards.Add(retard);
        Console.WriteLine($"{etudiant.nom} a : {retard.NbRetard} min de retard");

    }
    public void DemanderInformations()
    {
        Console.WriteLine("Veuillez entrer vos identifiants.");
        Console.Write("Nom d'utilisateur : ");
        string nomUtilisateur = Console.ReadLine();
        Console.Write("Mot de passe : ");
        string motDePasse = Console.ReadLine();

        // Vérifier si les identifiants sont corrects
        if (db.CheckLogin(nomUtilisateur, motDePasse))
        {
            Console.WriteLine("Connexion réussie !");
        }
        else
        {
            Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect.");
        }

        
        Console.WriteLine("Ajoute d'un Etudiant: ");
        Console.Write("Entrez le nom de l'étudiant: ");
        string nomEtudiant = Console.ReadLine();
    
        Console.Write("Entrer le Prenom de l'étudiant: ");
        string prenomEtudiant = Console.ReadLine();

        
        var nouvelEtudiant = new Étudiant { nom = nomEtudiant, prenom = prenomEtudiant };
        AjouterEtudiant(nouvelEtudiant);
        
        db.InsertEtudiant(nouvelEtudiant);

        Console.WriteLine("Ajoute d'un professeur: ");
        Console.Write("Entrez le nom de professeur: ");
        string nomProfesseur = Console.ReadLine();
        Console.Write("Entrer le prenom de professeur: ");
        string prenomProfesseur = Console.ReadLine();
    
        
        var nouveauProfesseur = new Professeur { nom = nomProfesseur, prenom = prenomProfesseur };
        AjouterProfesseur(nouveauProfesseur);
        
        //methode d'insertion
        db.InsertProf(nouveauProfesseur);
    
        Console.WriteLine("Ajoute d'une matiere : ");
        Console.Write("Entrez le nom de la matiere : ");
        string nomMatiere = Console.ReadLine();
        Console.Write("Entrez le coeficient de la matiere : ");
        int coeficient = Convert.ToInt32(Console.ReadLine());
    
        
        var nouvelleMatiere = new Matière { NomMatiere = nomMatiere, coefMatiere = coeficient };
        AjouterMatiere(nouvelleMatiere);
        
        //Insert Matiere
        
        db.InsertMatiere(nouvelleMatiere);
        
        // Demander le nom et le prénom de l'étudiant
        Console.WriteLine("Ajouter une note pour un étudiant.");
        Console.Write("Nom de l'étudiant : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom de l'étudiant : ");
        string prenom = Console.ReadLine();

        // Rechercher l'étudiant dans la base de données
        int etudiantId = db.GetEtudiantId(nom, prenom);

        if (etudiantId != -1)
        {
            // Si l'étudiant existe, demander la matière et la note
            Console.Write("Matière : ");
            string matiere = Console.ReadLine();
            Console.Write("Note : ");
            double note = Convert.ToDouble(Console.ReadLine());

            // Ajouter la note dans la base de données
            db.AjouterNote(etudiantId, matiere, note);
        }
        else
        {
            Console.WriteLine("Étudiant non trouvé.");
        }
        
        // Console.WriteLine("Ajout de notes: ");
        // Console.Write("Entrez la note de l'étudiant pour la matiere: ");
        // double note = Convert.ToDouble(Console.ReadLine());
        // var etudiant = etudiants.FirstOrDefault(e => e.nom == nomEtudiant);
        //
        // if (etudiant != null)
        // {
        //     if (!etudiant.NotesParMatiére.ContainsKey(nomMatiere))
        //     {
        //         etudiant.NotesParMatiére[nomMatiere] = new List<double>();
        //     }
        //     etudiant.NotesParMatiére[nomMatiere].Add(note);
        //     Console.WriteLine($"Note {note} ajoutée pour {nomEtudiant} dans {nomMatiere}.");
        //     
        // }
        // else
        // {
        //     Console.WriteLine("Étudiant non trouvé.");
        // }
        
    //     Console.WriteLine("Ajoute d'absence : ");
    //     Console.Write("Entrer le nombre d'absence : ");
    //     string nomAbsence = Console.ReadLine();
    //     var nouveauAbsence = new Absence { NbAbsence = nomAbsence };
    //
    //     if (etudiant != null)
    //     {
    //         AjouterAbsence(nouveauAbsence , etudiant);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Etudiant non trouver");
    //     }
    //
    //     Console.WriteLine("Nobre de retard : ");
    //     Console.Write("Entrer le nobre de retards : ");
    //     string nombreRetards = Console.ReadLine();
    //     var nouveauRetard = new Retard {NbRetard = nombreRetards};
    //     if (etudiant != null)
    //     {
    //         AjouterRetard(nouveauRetard , etudiant);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Etudiant non trouver");
    //     }
    //
    //
    // }
    }
    
}