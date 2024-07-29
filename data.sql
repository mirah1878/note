------------------------------------------------------ admin ---------------------------------------------------------
    insert into admin (nom,password) values 
        ('admin','1234');

------------------------------------------------------ Promotion ---------------------------------------------------------
insert into promotion (nom) values 
    ('PROM1'),
    ('PROM2'),
    ('PROM3');

------------------------------------------------------ Etudiant  ---------------------------------------------------------
INSERT INTO etudiant (id_promotion, num_etu, nom, prenom, date_de_naissance) VALUES
('PROM001', '001', 'Ranaivo', 'Hery', '2000-01-01'),
('PROM001', '002', 'Rasoa', 'Miora', '2000-01-02'),
('PROM001', '003', 'Randria', 'Tsiriry', '2000-01-03'),
('PROM002', '004', 'Ramalala', 'Lanto', '2000-01-04'),
('PROM002', '005', 'Rakoto', 'Faly', '2000-01-05'),
('PROM002', '006', 'Rajao', 'Sariaka', '2000-01-06'),
('PROM003', '007', 'Ramafa', 'Maro', '2000-01-07'),
('PROM003', '008', 'Ralahy', 'Aina', '2000-01-08'),
('PROM003', '009', 'Ramaro', 'Tsanta', '2000-01-09');

------------------------------------------------------ Semestre ---------------------------------------------------------
insert into semestre (nom) values 
    ('semestre 1'),
    ('semestre 2'),
    ('semestre 3'),
    ('semestre 4'),
    ('semestre 5'),
    ('semestre 6');
------------------------------------------------------ Semestre 1 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values 
    ('SMTR001', 'INF101','Programmation procédurale',7, 0),
    ('SMTR001', 'INF104','HTML et Introduction au Web',5, 0),
    ('SMTR001', 'INF107','Informatique de Base',4, 0),
    ('SMTR001', 'MTH101','Arithmétique et nombres',4, 0),
    ('SMTR001', 'MTH102','Analyse mathématique',6, 0),
    ('SMTR001', 'ORG101','Techniques de communication',4, 0);

---------------------------------------- Total 30

------------------------------------------------------ Semestre 2 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values 
    ('SMTR002', 'INF102','Bases de données relationnelles',5, 0),
    ('SMTR002', 'INF103','Bases de l''administration système',5, 0),
    ('SMTR002', 'INF105','Maintenance matériel et logiciel',4, 0),
    ('SMTR002', 'INF106','Compléments de programmation',6, 0),
    ('SMTR002', 'MTH103','Calcul Vectoriel et Matriciel',6, 0),
    ('SMTR002', 'MTH105','Probabilité et Statistique',4, 0);

---------------------------------------- Total 30

------------------------------------------------------ Semestre 3 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values
    ('SMTR003', 'INF201','Programmation orientée objet',6, 0),
    ('SMTR003', 'INF202','Bases de données objets',6, 0),
    ('SMTR003', 'INF203','Programmation système',4, 0),
    ('SMTR003', 'INF208','Réseaux informatiques',6, 0),
    ('SMTR003', 'MTH201','Méthodes numériques',4, 0),
    ('SMTR003', 'ORG201','Bases de gestion',4, 0);

---------------------------------------- Total 30
---------------------------------------- Total du parcours 90

------------------------------------------------------ Semestre 4 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values 
    ('SMTR004', 'INF204','Système d''information géographique',6, 's4_inf'), -- 1 UE parmi 
    ('SMTR004', 'INF205','Système d''information',6, 's4_inf'), -- 1 UE parmi
    ('SMTR004', 'INF206','Interface Homme/Machine',6, 's4_inf'),-- 1 UE parmi

    ('SMTR004', 'INF207','Eléments d''algorithmique',6, 0),
    ('SMTR004', 'INF210','Mini-projet de développement',10, 0),

    ('SMTR004', 'MTH204','Géométrie', 4, 's4_math'), -- 1 UE parmi
    ('SMTR004', 'MTH205','Equations différentielles', 4, 's4_math'), -- 1 UE parmi
    ('SMTR004', 'MTH206','Optimisation',4, 's4_math'), -- 1 UE parmi

    ('SMTR004', 'MTH203','MAO',4, 0);

---------------------------------------- Total 30

------------------------------------------------------ Semestre 5 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values   
    ('SMTR005', 'INF301','Architecture logicielle',6, 0),
    ('SMTR005', 'INF304','Développement pour mobiles',6, 0),
    ('SMTR005', 'INF307','Conception en modèle orienté objet',6, 0),
    ('SMTR005', 'ORG301','Gestion d''entreprise',5, 0),
    ('SMTR005', 'ORG302','Gestion de projets',4, 0),
    ('SMTR005', 'ORG303','Anglais pour les affaires',3, 0);

---------------------------------------- Total 30

------------------------------------------------------ Semestre 6 ---------------------------------------------------------
insert into matiere (id_semestre, code, nom, credit, optionnelle) values 
    ('SMTR006', 'INF310','Codage',4, 0),
    ('SMTR006', 'INF313','Programmation avancée, frameworks',6, 0),

    ('SMTR006', 'INF302','Technologies d''accès aux réseaux', 6, 's6_inf'), -- 1 UE parmi
    ('SMTR006', 'INF303','Multimédia',6, 's6_inf'), -- 1 UE parmi

    ('SMTR006', 'INF316','Projet de développement',10, 0),
    ('SMTR006', 'ORG304','Communication d''entreprise',4, 0);

---------------------------------------- Total 30
---------------------------------------- Total du parcours 90
-- etudiant n°1 note s4 et s6 -----------------------------------------------------------------------------------------
insert into note(id_etudiant,id_matiere,note) values 
    ('ET000001','MT019',10),
    ('ET000001','MT020',13.5),
    ('ET000001','MT021',11),
    ('ET000001','MT022',12),
    ('ET000001','MT023',12),
    ('ET000001','MT024',15),
    ('ET000001','MT025',10),
    ('ET000001','MT026',15),
    ('ET000001','MT027',8);

insert into note(id_etudiant,id_matiere,note) values 
    ('ET000001','MT034',18),
    ('ET000001','MT035',5),
    ('ET000001','MT036',7),
    ('ET000001','MT037',8),
    ('ET000001','MT038',8),
    ('ET000001','MT039',6);

-- etudiant n°4 note s4 et s6 --------------------------------------------------------------------------------------------
insert into note(id_etudiant,id_matiere,note) values 
    ('ET000004','MT019',8),
    ('ET000004','MT020',10),
    ('ET000004','MT021',11),
    ('ET000004','MT022',12),
    ('ET000004','MT023',10.75),
    ('ET000004','MT024',13.5),
    ('ET000004','MT025',15),
    ('ET000004','MT026',13),
    ('ET000004','MT027',11.5);

insert into note(id_etudiant,id_matiere,note) values 
    ('ET000004','MT034',10),
    ('ET000004','MT035',11),
    ('ET000004','MT036',14),
    ('ET000004','MT037',14.5),
    ('ET000004','MT038',12),
    ('ET000004','MT039',7.5);




 

 