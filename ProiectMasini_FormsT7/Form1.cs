using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using LibrarieModele;
using NivelAccesDate;
using ManagerM;

namespace ProiectMasini_FormsT7
{
    public partial class Form1 : Form
    {

        IStocareData adminMasini;
        ArrayList optiuniSelectate = new ArrayList();

        public int idMasina { get; set; }

        public Form1()
        {
            InitializeComponent();
            adminMasini = ManagerMasini.GetAdministratorStocare();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void adaugaBtn_Click(object sender, EventArgs e)
        {
            Masina masina;

            firmaLbl.ForeColor = Color.Black;
            modelLbl.ForeColor = Color.Black;
            anFLbl.ForeColor = Color.Black;
            culoareLbl.ForeColor = Color.Black;
            numeVanzatorLbl.ForeColor = Color.Black;
            numeCumparatorLbl.ForeColor = Color.Black;
            dataLbl.ForeColor = Color.Black;
            pretLbl.ForeColor = Color.Black;
            optiuniLbl.ForeColor = Color.Black;

            firmaTxt.ForeColor = Color.Black;
            modelTxt.ForeColor = Color.Black;
            anFTxt.ForeColor = Color.Black;
            culoareTxt.ForeColor = Color.Black;
            numeVanzatorTxt.ForeColor = Color.Black;
            numeCumparatorTxt.ForeColor = Color.Black;
            dataTxt.ForeColor = Color.Black;
            pretTxt.ForeColor = Color.Black;
            optiuniTxt.ForeColor = Color.Black;
            CodEroare valideaza = Validare(firmaTxt.Text, modelTxt.Text,culoareTxt.Text,
                anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text, dataTxt.Text, pretTxt.Text,optiuniTxt.Text);
            if (valideaza != CodEroare.CORECT)
            {
                switch (valideaza)
                {
                    case CodEroare.FIRMA_INCORECTA:
                        firmaTxt.ForeColor = Color.Red;
                        if (firmaTxt.Text == string.Empty)
                            firmaLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.MODEL_INCORECT:
                        modelTxt.ForeColor = Color.Red;
                        if (modelTxt.Text == string.Empty)
                            modelLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.CULOARE_INCORECTA:
                        culoareTxt.ForeColor = Color.Red;
                        if (culoareTxt.Text == string.Empty)
                            culoareLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.AN_FABRICATIE_INCORECT:
                        anFTxt.ForeColor = Color.Red;
                        if (anFTxt.Text == string.Empty)
                            anFLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_VANZATOR_INCORECT:
                        numeVanzatorTxt.ForeColor = Color.Red;
                        if (numeVanzatorTxt.Text == string.Empty)
                            numeVanzatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_CUMPARATOR_INCORECT:
                        numeCumparatorTxt.ForeColor = Color.Red;
                        if (numeCumparatorTxt.Text == string.Empty)
                            numeCumparatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.DATA_INCORECTA:
                        dataTxt.ForeColor = Color.Red;
                        if (dataTxt.Text == string.Empty)
                            dataLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.PRET_INCORECT:
                        pretTxt.ForeColor = Color.Red;
                        if (pretTxt.Text == string.Empty)
                            pretLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.OPTIUNI_INCORECTE:
                        optiuniTxt.ForeColor = Color.Red;
                        if (optiuniTxt.Text == string.Empty)
                            optiuniLbl.ForeColor = Color.Red;
                        break;
                }
            }
            else
            {
                string optiuniMasinaForm = OptiuniAsString();
                masina = new Masina(numeVanzatorTxt.Text.ToString(), numeCumparatorTxt.Text.ToString()
                , firmaTxt.Text.ToString(), modelTxt.Text.ToString(), Convert.ToInt32(anFTxt.Text.ToString()),
                culoareTxt.Text.ToString(),optiuniMasinaForm,dataTxt.Text.ToString(), Convert.ToDouble(pretTxt.Text.ToString()),"Sedan",DateTime.Now);
                



                masina.Optiuni = new ArrayList();
                masina.Optiuni.AddRange(optiuniSelectate);

                ManagerMasini.addMasina(masina);
                afisareLbl.Text = "Masina a fost adaugata";

                //ResetareControale();
            }

            ResetareControale();

        }

        private CodEroare Validare(string firma, string model,string culoare,string anFabricatie,
                      string numeVanzator, string numeCumparator, string dataTranzactie, string pret,string optiuni)
        {

            if (firma == string.Empty)
            {
                return CodEroare.FIRMA_INCORECTA;
            }
            else if (model == string.Empty)
            {
                return CodEroare.MODEL_INCORECT;
            }
            else if (culoare == string.Empty)
            {
                return CodEroare.CULOARE_INCORECTA;
            }
            else if (anFabricatie == string.Empty)
            {
                return CodEroare.AN_FABRICATIE_INCORECT;
            }
            else if (numeVanzator == string.Empty)
            {
                return CodEroare.NUME_VANZATOR_INCORECT;
            }
            else if (numeCumparator == string.Empty)
            {
                return CodEroare.NUME_CUMPARATOR_INCORECT;
            }
            else if (dataTranzactie == string.Empty)
            {
                return CodEroare.DATA_INCORECTA;
            }
            else if (pret == string.Empty)
            {
                return CodEroare.PRET_INCORECT;
            }
            else if (optiuni == string.Empty)
            {
                return CodEroare.OPTIUNI_INCORECTE;
            }


            return CodEroare.CORECT;
        }

        public string OptiuniAsString()
        {

            return optiuniTxt.Text;

        }

        private void ResetareControale()
        {
            firmaTxt.Text = string.Empty;
            modelTxt.Text = string.Empty;
            anFTxt.Text = string.Empty;
            numeVanzatorTxt.Text = string.Empty;
            numeCumparatorTxt.Text = string.Empty;
            dataTxt.Text = string.Empty;
            pretTxt.Text = string.Empty;
            culoareTxt.Text = string.Empty;
            optiuniTxt.Text = string.Empty;
            //lblMesaj.Text = string.Empty;
        }

        private void afiseazaBtn_Click(object sender, EventArgs e)
        {
            List<Masina> masini = new List<Masina>(ManagerMasini.getMasiniList());
            File.WriteAllText(@"C:\Users\sebyg\source\repos\ProiectMasiniPIU\ProiectMasiniPIU\MasiniSalvate.txt", String.Empty);

            afisareRichTextBox.Clear();
            var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie","Firma","Model","Culoare","An fabricatie","Pret");
            afisareRichTextBox.AppendText(antetTabel);

            foreach (Masina m in masini)
            {
                int calculId = -8 - m.getIdMasina().ToString().Length+1;
                int calculNumeVanzator = -30 - m.numeVanzator.Length+10;
                int calculNumeCumparator = -30 - m.numeCumparator.Length+7;
                int calculData = -20 - m.dataTranzactie.Length + 6;
                int calculFirma = -15 - m.firmaProp.Length + 4;
                int calculModel = -15 - m.modelProp.Length + 3;
                int calculCuloare = -14 - m.culoareProp.Length + 4;
                int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                int calculPret = -10 - m.pretProp.ToString().Length + 1;
                
                var mAfisare= String.Format("\n{0,"+calculId.ToString()+"}{1,"+calculNumeVanzator.ToString()+"}{2,"+calculNumeCumparator.ToString()+"}{3,"+calculData.ToString()+"}{4,"+calculFirma.ToString()+"}{5,"+calculModel.ToString()+"}{6,"+calculCuloare.ToString()+"}{7,"+calculAn.ToString()+"}{8,"+calculPret.ToString()+"}\n",
                    m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                afisareRichTextBox.AppendText(mAfisare);
                afisareRichTextBox.AppendText("\t\t" + m.OptiuniAsString);
                afisareRichTextBox.AppendText(Environment.NewLine);
                adminMasini.AddMasina(m);
            }
            afisareLbl.Text = "Lista cu masini a fost afisata";

        }

        private void cautaBtn_Click(object sender, EventArgs e)
        {
            //ResetareControale();
            if (firmaTxt.Text == string.Empty && modelTxt.Text == string.Empty && numeVanzatorTxt.Text == string.Empty && numeCumparatorTxt.Text == string.Empty && culoareTxt.Text == string.Empty && dataTxt.Text == string.Empty && anFTxt.Text == string.Empty && pretTxt.Text == string.Empty && optiuniTxt.Text == string.Empty)
            {
                optiuniTxt.Enabled = false;
                afisareLbl.Text = "Introduceti datele corespunzatoare cautarii...";
            }
            else
            {
                afisareRichTextBox.Clear();
                List<Masina> cautari = new List<Masina>(ManagerMasini.CautareMasiniForms(firmaTxt.Text, modelTxt.Text,
                                        "rosu", anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text,
                                        dataTxt.Text, pretTxt.Text, "ABS"));

                var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
                afisareRichTextBox.AppendText(antetTabel);

                foreach (Masina m in cautari)
                {
                    int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                    int calculNumeVanzator = -30 - m.numeVanzator.Length + 1;
                    int calculNumeCumparator = -30 - m.numeCumparator.Length + 1;
                    int calculData = -20 - m.dataTranzactie.Length + 9;
                    int calculFirma = -15 - m.firmaProp.Length + 4;
                    int calculModel = -15 - m.modelProp.Length + 6;
                    int calculCuloare = -14 - m.culoareProp.Length + 4;
                    int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                    int calculPret = -10 - m.pretProp.ToString().Length + 1;

                    var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                        m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                    afisareRichTextBox.AppendText(mAfisare);
                    afisareRichTextBox.AppendText("\t\t" + m.OptiuniAsString);
                    afisareRichTextBox.AppendText(Environment.NewLine);
                }
                afisareLbl.Text = "Cautarile au fost efectuate";
                ResetareControale();
                optiuniTxt.Enabled = true;
            }
        }

        private void modificaBtn_Click(object sender, EventArgs e)
        {
            if (firmaTxt.Text == string.Empty && modelTxt.Text == string.Empty && numeVanzatorTxt.Text == string.Empty && numeCumparatorTxt.Text == string.Empty && culoareTxt.Text == string.Empty && dataTxt.Text == string.Empty && anFTxt.Text == string.Empty && pretTxt.Text == string.Empty && optiuniTxt.Text == string.Empty)
            {
                afisareRichTextBox.Clear();
                List<Masina> listaMasini = new List<Masina>(ManagerMasini.getMasiniList());

                foreach (Masina m in listaMasini)
                {
                    afisareRichTextBox.AppendText(m.toString());
                    afisareRichTextBox.AppendText(Environment.NewLine);
                }
                afisareLbl.Text = "Introduceti noile modificari";

                Modifica modificaForm = new Modifica();
                modificaForm.ShowDialog();
                int id = Convert.ToInt32(modificaForm.getId());
                Masina masina = ManagerMasini.getMasina(id);
                firmaTxt.Text = masina.firmaProp;
                modelTxt.Text = masina.modelProp;
                anFTxt.Text = masina.anFabricatie.ToString();
                culoareTxt.Text = masina.culoareProp;
                numeCumparatorTxt.Text = masina.numeCumparator;
                numeVanzatorTxt.Text = masina.numeVanzator;
                pretTxt.Text = masina.pretProp.ToString();
                dataTxt.Text = masina.dataTranzactie;
                optiuniTxt.Text = masina.OptiuniAsString;

                idMasina = id;
            }
            else
            {
                Masina masina = ManagerMasini.getMasina(idMasina);
                masina.firmaProp = firmaTxt.Text;
                masina.modelProp = modelTxt.Text;
                masina.anFabricatie = Convert.ToInt32(anFTxt.Text);
                masina.culoareProp = culoareTxt.Text;
                masina.identificaCuloare();
                masina.numeVanzator = numeVanzatorTxt.Text;
                masina.numeCumparator = numeCumparatorTxt.Text;
                masina.dataTranzactie = dataTxt.Text;
                masina.pretProp = Convert.ToDouble(pretTxt.Text);
                if (OptiuniAsString() != string.Empty)
                    masina.setOptiuni(OptiuniAsString());

                afisareRichTextBox.Clear();
                afisareRichTextBox.AppendText(masina.toString());
                ResetareControale();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
