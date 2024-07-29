using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
     
    public DbSet<Admin> _admin {get; set;}
 
    public DbSet<Note> _note {get; set;}
 
    public DbSet<Promotion> _promotion {get; set;}
 
    public DbSet<Etudiant> _etudiant {get; set;}
 
    public DbSet<Semestre> _semestre {get; set;}
 
    public DbSet<Matiere> _matiere {get; set;}
    public DbSet<VnoteEtudiantParSemestre> _vnoteEtudiantParSemestre {get; set;}
    public DbSet<NoteTemporaire> _notetemp {get; set; }
    public DbSet<Genre> _genre {get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
        // Configuration de la séquence pour TypeProduits
        
            modelBuilder.Entity<Admin>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR admin_seq");

            modelBuilder.Entity<Note>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR note_seq");

            modelBuilder.Entity<Promotion>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR promotion_seq");

            modelBuilder.Entity<Etudiant>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR etudiant_seq");

            modelBuilder.Entity<Semestre>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR semestre_seq");

            modelBuilder.Entity<Matiere>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR matiere_seq");

            modelBuilder.Entity<VnoteEtudiantParSemestre>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR v_notes_etudiants_par_semestre_seq");


            modelBuilder.Entity<Genre>()
                .Property(p => p.Id)
                .HasDefaultValueSql($"NEXT VALUE FOR genre_seq");

            modelBuilder.Entity<NoteTemporaire>().HasNoKey();

    }
}