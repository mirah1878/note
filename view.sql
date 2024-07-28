CREATE VIEW v_etudiants AS
    SELECT 
        e.*,
        p.nom as nom_promotion,
        s.id as id_semestre,
        s.nom as nom_semestre,
        m.id as id_matiere, 
        m.nom as nom_matiere,
        m.code as code_matiere,
        m.credit as credit_matiere,
        m.optionnelle,
        n.note
    FROM etudiant AS e
    JOIN promotion AS p ON e.id_promotion = p.id
    LEFT JOIN note AS n ON e.id = n.id_etudiant
    JOIN matiere AS m ON n.id_matiere = m.id
    JOIN semestre AS s ON m.id_semestre = s.id;

----------------------------------- maka max note le math optionnelle s4 -------------------------------------------------
CREATE VIEW v_max_note_math_s4 AS
    SELECT ve.* 
    FROM v_etudiants as ve
    JOIN (select id, max(note) as note from v_etudiants where optionnelle = 's4_math' group by id) as s4m
    ON ve.id = s4m.id AND ve.note = s4m.note 
    where optionnelle = 's4_math';

----------------------------------- maka max note le inf optionnelle s4 -------------------------------------------------
CREATE VIEW v_max_note_inf_s4 AS
    SELECT ve.* 
    FROM v_etudiants as ve
    JOIN (select id, max(note) as note from v_etudiants where optionnelle = 's4_inf' group by id) as s4i
    ON ve.id = s4i.id AND ve.note = s4i.note 
    where optionnelle = 's4_inf';

----------------------------------- maka max note le inf optionnelle s6 -------------------------------------------------
CREATE VIEW v_max_note_inf_s6 AS
    SELECT ve.* 
    FROM v_etudiants AS ve
    JOIN (select id, max(note) as note from v_etudiants where optionnelle = 's6_inf' group by id) AS s6i
    ON ve.id = s6i.id AND ve.note = s6i.note 
    WHERE optionnelle = 's6_inf';

----------------------------------- liste note efa ze ambony note le matiere optionnelle  -------------------------------------------------
CREATE OR REPLACE VIEW v_releve_note AS
(select * from v_etudiants where optionnelle is NULL) 
UNION 
(select * from v_max_note_math_s4)
UNION
(select * from v_max_note_inf_s4)
UNION
(select * from v_max_note_inf_s6);

----------------------------------- moyenne ana etudiant par semestre -------------------------------------------------
CREATE OR REPLACE VIEW v_moyene_etudiant_par_semestre AS
SELECT id, id_semestre, ((sum(credit_matiere * note)/sum(credit_matiere))::NUMERIC(10,2)) AS moyenne
FROM v_releve_note GROUP BY id, id_semestre; 

----------------------------------- note etudiant efa miaraka (ajournee, composer, valider) -------------------------------------------------
-- ajournee   -1
-- compose     0
-- valider     1
CREATE OR REPLACE VIEW v_notes_etudiants_par_semestre AS
SELECT 
    vrn.*,
    vmes.moyenne,
    CASE 
        WHEN vmes.moyenne < 10 AND vrn.note < 10 THEN -1
        WHEN vmes.moyenne >= 10 THEN
            CASE
                WHEN (vrn.note < 10 AND vrn.note >= 6) THEN 0 
                WHEN vrn.note < 6 THEN -1
                ELSE 1
             END
        ELSE 1
    END AS etat
FROM v_releve_note AS vrn
JOIN v_moyene_etudiant_par_semestre AS vmes ON vrn.id = vmes.id AND vrn.id_semestre = vmes.id_semestre;

-- -- -- -- --- --- ---- ---- -- ----- -- --- -----
select * from v_notes_etudiants_par_semestre order by id, id_semestre;
