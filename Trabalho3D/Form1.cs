using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho3D.Scanline;

namespace Trabalho3D
{
    public partial class Form1 : Form
    {
        private Image img;
        private Bitmap imgBmp, ret;
        private ArrayList lVertOriginais = new ArrayList();
        private ArrayList lVertAtual = new ArrayList();
        private ArrayList lFace = new ArrayList();
        private ArrayList lVetorNormal = new ArrayList();
        private Boolean ctrClick;
        private int mx;
        private int my;
        private int ctrX;
        private int ctrY;
        private int ctrZ;
        private int pcX;
        private int pcY;
        private int pcZ;
        private Boolean btnCtrl;
        private int r;
        private int g;
        private int b;
        private int qtdePontos;

        public Form1()
        {
            InitializeComponent();
            EstadoInicial();
            this.pictureBox.MouseWheel += MouseWheel;
            BloqueioDeOpcoes(false);
        }

        private void EstadoInicial()
        {
            CarregarFundo();
            Transformacao.ZerarMatriz();
            lVertOriginais = new ArrayList();
            lVertAtual = new ArrayList();
            lFace = new ArrayList();
            lVetorNormal = new ArrayList();
            mx = my = -1;
            pcX = pcY = -1;

            rbFrontal.Checked = true;
            cbBackFaceCulling.Checked = false;

            btnCorAtual.BackColor = Color.White;
            r = g = b = 255;
            AtualizarCor();
            btnColorir.Text = "Colorir";
            qtdePontos = 0;
        }

        private void BloqueioDeOpcoes(Boolean flag)
        {
            cbBackFaceCulling.Enabled = flag;
            rbFrontal.Enabled = flag;
            rbSuperior.Enabled = flag;
            rbLateral.Enabled = flag;
            rbCabinet.Enabled = flag;
            rbCavaleira.Enabled = flag;

            btnCorAtual.Enabled = flag;
            btnColorir.Enabled = flag;
        }

        private void CarregarFundo()
        {
            String caminho = Application.StartupPath.ToString() + "\\Fundo.png";
            img = Image.FromFile(caminho);
            imgBmp = (Bitmap)img;
            pictureBox.Image = img;
            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void Desenhar()
        {
            CarregarFundo();
            if (rbFrontal.Checked)
                OrtograficaFrontal();
            else
            if (rbSuperior.Checked)
                OrtograficaSuperior();
            else
            if (rbLateral.Checked)
                OrtograficaLateral();
            else
            {
                double[][] mat = new double[4][];
                for (int i = 0; i < 4; i++)
                    mat[i] = new double[4];

                mat[0][0] = 1;
                mat[1][1] = 1;
                mat[3][3] = 1;

                if (rbCabinet.Checked)
                {
                    mat[2][0] = 0.5 * Math.Cos(63.4 * Math.PI / 180);
                    mat[2][0] = 0.5 * Math.Sin(63.4 * Math.PI / 180);

                    ProjecaoObliqua(mat);
                }
                else
                if (rbCavaleira.Checked)
                {
                    mat[2][0] = 0.5 * Math.Cos(45 * Math.PI / 180);
                    mat[2][0] = 0.5 * Math.Sin(45 * Math.PI / 180);

                    ProjecaoObliqua(mat);
                }
                    
            }
        }

        private void MultiplicarPontos()
        {
            int i;
            Pontos p;
            double[] ret;

            for (i = 0; i < lVertOriginais.Count; i++)
            {
                p = (Pontos)(lVertOriginais[i]);

                ret = Transformacao.MatrizAcumulada(p.getX(), p.getY(), p.getZ());
                ((Pontos)(lVertAtual[i])).setX(ret[0]);
                ((Pontos)(lVertAtual[i])).setY(ret[1]);
                ((Pontos)(lVertAtual[i])).setZ(ret[2]);//Ver o problema do z
            }
        }

        public void PontoCentral(Boolean flag)
        {
            int i;
            int menX, menY, menZ, maiX, maiY, maiZ;

            maiX = menX = ((Pontos)lVertAtual[0]).getX();
            maiY = menY = ((Pontos)lVertAtual[0]).getY();
            maiZ = menZ = ((Pontos)lVertAtual[0]).getZ();
            for (i = 1; i < lVertAtual.Count; i++)
            {
                if (menX > ((Pontos)lVertAtual[i]).getX())
                    menX = ((Pontos)lVertAtual[i]).getX();
                else
                if (maiX < ((Pontos)lVertAtual[i]).getX())
                    maiX = ((Pontos)lVertAtual[i]).getX();

                if (menY > ((Pontos)lVertAtual[i]).getY())
                    menY = ((Pontos)lVertAtual[i]).getY();
                else
                if (maiY < ((Pontos)lVertAtual[i]).getY())
                    maiY = ((Pontos)lVertAtual[i]).getY();

                if (menZ > ((Pontos)lVertAtual[i]).getZ())
                    menZ = ((Pontos)lVertAtual[i]).getZ();
                else
                if (maiZ < ((Pontos)lVertAtual[i]).getZ())
                    maiZ = ((Pontos)lVertAtual[i]).getZ();
            }

            if (flag)
            {
                ctrX = (int)(450 - (Math.Abs((menX + maiX) / 2)));
                ctrY = (int)(425 - (Math.Abs((menY + maiY) / 2)));
            }
            else
            {
                pcX = (int)(Math.Abs((menX + maiX) / 2));
                pcY = (int)(Math.Abs((menY + maiY) / 2));
                pcZ = (int)(Math.Abs((menZ + maiZ) / 2));
            }
        }

        private void Escala(double dx, double dy, double dz)
        {
            Transformacao.Escala(dx,dy,dz);
        }

        private void Transladar(int dx, int dy, int dz)
        {
            if(rbSuperior.Checked)
                Transformacao.Translacao(dx, dz, dy);
            else
            if (rbLateral.Checked)
                Transformacao.Translacao(dy, dx,dy+ dz);
            else
                Transformacao.Translacao(dx, dy, dz);
        }

        private void Rotacionar(int x, int y, int z)
        {
            if (pcX == -1)
                PontoCentral(false);//Centro da imagem
            Transladar(-1 * pcX, -1 * pcY, -1*pcZ);

            if (x != 0)
                Transformacao.RotacaoX(x);
            if (y != 0)
                Transformacao.RotacaoY(y);
            if (z != 0)
                Transformacao.RotacaoZ(z);

            Transladar(pcX, pcY, pcZ);
        }
        /* Projecoes */

        private void OrtograficaFrontal()
        {
            int j;
            No face;
            Pontos[] p;
            qtdePontos = 0;

            ret = imgBmp;

            Reta.IniciarMatriz();

            for (int i = 0; i < lFace.Count; i++)
            {
                face = ((No)(lFace[i]));
                p = new Pontos[face.getCount()];

                j = 0;
                while (face != null)
                {
                    p[j] = (Pontos)lVertAtual[face.getPos()];
                    j++;
                    face = face.getProx();
                }
                p[j] = p[0];

                Pontos vertAB = new Pontos(p[1].getX() - p[0].getX(), p[1].getY() - p[0].getY(), p[1].getZ() - p[0].getZ());
                Pontos vertAC = new Pontos(p[2].getX() - p[0].getX(), p[2].getY() - p[0].getY(), p[2].getZ() - p[0].getZ());

                if (lVetorNormal.Count <= i)
                    lVetorNormal.Add(new Vetor(vertAB, vertAC));
                else
                    lVetorNormal[i] = new Vetor(vertAB, vertAC);

                if (cbBackFaceCulling.Checked)
                {
                    if (((Vetor)lVetorNormal[i]).getZ() > 0)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            Reta.Bresenham(p[k].getX(), p[k].getY(), p[k + 1].getX(), p[k + 1].getY());//pintanto
                            qtdePontos++;
                        }
                    }
                }
                else
                {
                    for(int k = 0; k < j; k++)
                    {
                        Reta.Bresenham(p[k].getX(), p[k].getY(), p[k + 1].getX(), p[k + 1].getY());//pintanto
                        qtdePontos++;
                    }
                }
            }

            Reta.AlocarBitmap(ret);
            Reta.Desenhar();
            if (btnColorir.Text.Equals("Colorir"))
            {
                //ScanLine.Scanline(Reta.getImgDta());
            }
            Reta.DesalocarBitmap(ret);

            pictureBox.Image = ret;
            imgBmp = ret;
        }

        private void OrtograficaSuperior()
        {
            int j;
            No face;
            Pontos[] p;

            ret = imgBmp;

            Reta.IniciarMatriz();
            for (int i = 0; i < lFace.Count; i++)
            {
                face = ((No)(lFace[i]));
                p = new Pontos[face.getCount()];

                j = 0;
                while (face != null)
                {
                    p[j] = (Pontos)lVertAtual[face.getPos()];
                    j++;
                    face = face.getProx();
                }
                p[j] = p[0];

                Pontos vertAB = new Pontos(p[1].getX() - p[0].getX(), p[1].getY() - p[0].getY(), p[1].getZ() - p[0].getZ());
                Pontos vertAC = new Pontos(p[2].getX() - p[0].getX(), p[2].getY() - p[0].getY(), p[2].getZ() - p[0].getZ());

                if (lVetorNormal.Count <= i)
                    lVetorNormal.Add(new Vetor(vertAB, vertAC));
                else
                    lVetorNormal[i] = new Vetor(vertAB, vertAC);

                if (cbBackFaceCulling.Checked)
                {
                    if (((Vetor)lVetorNormal[i]).getY() > 0)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            Reta.Bresenham(p[k].getX(), p[k].getZ() + 425, p[k + 1].getX(), p[k + 1].getZ() + 425);//pintanto
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < j; k++)
                    {
                        Reta.Bresenham(p[k].getX(), p[k].getZ() + 425, p[k + 1].getX(), p[k + 1].getZ() + 425);//pintanto
                    }
                }   
            }

            Reta.AlocarBitmap(ret);
            Reta.Desenhar();
            if (btnColorir.Text.Equals("Colorir"))
            {
                //ScanLine.Scanline(Reta.getImgDta());
            }
            Reta.DesalocarBitmap(ret);

            pictureBox.Image = ret;
            imgBmp = ret;
        }

        private void OrtograficaLateral()
        {
            int j;
            No face;
            Pontos[] p;

            ret = imgBmp;

            Reta.IniciarMatriz();
           
            for (int i = 0; i < lFace.Count; i++)
            {
                face = ((No)(lFace[i]));
                p = new Pontos[face.getCount()];

                j = 0;
                while (face != null)
                {
                    p[j] = (Pontos)lVertAtual[face.getPos()];
                    j++;
                    face = face.getProx();
                }
                p[j] = p[0];

                Pontos vertAB = new Pontos(p[1].getX() - p[0].getX(), p[1].getY() - p[0].getY(), p[1].getZ() - p[0].getZ());
                Pontos vertAC = new Pontos(p[2].getX() - p[0].getX(), p[2].getY() - p[0].getY(), p[2].getZ() - p[0].getZ());

                if (lVetorNormal.Count <= i)
                    lVetorNormal.Add(new Vetor(vertAB, vertAC));
                else
                    lVetorNormal[i] = new Vetor(vertAB, vertAC);

                if (cbBackFaceCulling.Checked)
                {
                    if (((Vetor)lVetorNormal[i]).getX() > 0)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            Reta.Bresenham(p[k].getY() + 100, p[k].getZ() + 425, p[k + 1].getY() + 100, p[k + 1].getZ() + 425);//pintanto
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < j; k++)
                    {
                        Reta.Bresenham(p[k].getY() + 100, p[k].getZ() + 425, p[k + 1].getY() + 100, p[k + 1].getZ() + 425);//pintanto
                    }
                }
            }

            Reta.AlocarBitmap(ret);
            Reta.Desenhar();
            if (btnColorir.Text.Equals("Colorir"))
            {
                //ScanLine.Scanline(Reta.getImgDta());
            }
            Reta.DesalocarBitmap(ret);

            pictureBox.Image = ret;
            imgBmp = ret;
        }

        private void ProjecaoObliqua(double[][] mat)
        {
            int j;
            double[] p1, p2;
            No face;
            Pontos[] p;

            ret = imgBmp;

            Reta.IniciarMatriz();
            for (int i = 0; i < lFace.Count; i++)
            {
                face = ((No)(lFace[i]));
                p = new Pontos[face.getCount()];

                j = 0;
                while (face != null)
                {
                    p[j] = (Pontos)lVertAtual[face.getPos()];
                    j++;
                    face = face.getProx();
                }
                p[j] = p[0];

                Pontos vertAB = new Pontos(p[1].getX() - p[0].getX(), p[1].getY() - p[0].getY(), p[1].getZ() - p[0].getZ());
                Pontos vertAC = new Pontos(p[2].getX() - p[0].getX(), p[2].getY() - p[0].getY(), p[2].getZ() - p[0].getZ());

                if (lVetorNormal.Count <= i)
                    lVetorNormal.Add(new Vetor(vertAB, vertAC));
                else
                    lVetorNormal[i] = new Vetor(vertAB, vertAC);

                if (cbBackFaceCulling.Checked)
                {
                    if (((Vetor)lVetorNormal[i]).getZ() > 0)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            p1 = MultiplicarPontos(mat, p[k]);
                            p2 = MultiplicarPontos(mat, p[k + 1]);

                            Reta.Bresenham((int)p1[0], (int)p1[1], (int)p2[0], (int)p2[1]);
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < j; k++)
                    {
                        p1 = MultiplicarPontos(mat, p[k]);
                        p2 = MultiplicarPontos(mat, p[k + 1]);

                        Reta.Bresenham((int)p1[0], (int)p1[1], (int)p2[0], (int)p2[1]);
                    }
                }

            }

            Reta.AlocarBitmap(ret);
            Reta.Desenhar();
            if (btnColorir.Text.Equals("Colorir"))
            {
               // ScanLine.Scanline(Reta.getImgDta());
            }
            Reta.DesalocarBitmap(ret);

            pictureBox.Image = ret;
            imgBmp = ret;
        }

        private double[] MultiplicarPontos(double[][] mat, Pontos p)
        {
            int i, j;
            double[] vet = { p.getX(), p.getY(), p.getZ(), 1 };
            double[] resul = new double[4];

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    resul[i] += vet[j] * mat[j][i];
                }
            }

            for (i = 0; i < 4; i++)
                resul[i] = Math.Round(resul[i]);
            return resul;
        }

        /*Cor*/
        private void AtualizarCor()
        {
            for (int i = 0; i < lVertAtual.Count; i++)
            {
                ((Pontos)lVertAtual[i]).addRGB(r,g,b); 
            }
        }

        private Pontos[] GerarPoligono()
        {
            int j, tl = 0;
            No face;
            Pontos[] p;
            Pontos[] pol = new Pontos[qtdePontos];

            for (int i = 0; i < lFace.Count; i++)
            {
                face = ((No)(lFace[i]));
                p = new Pontos[face.getCount()];

                j = 0;
                while (face != null)
                {
                    p[j] = (Pontos)lVertAtual[face.getPos()];
                    j++;
                    face = face.getProx();
                }
                p[j] = p[0];

                if (cbBackFaceCulling.Checked)
                {
                    if (((Vetor)lVetorNormal[i]).getZ() > 0)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            pol[tl++] = p[k];
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < j; k++)
                    {
                        pol[tl++] = p[k];
                    }
                }
            }
            return pol;
        }

        public void Scanline()
        {
            Pontos[] pol = GerarPoligono();
            Reta.AlocarBitmap(ret);
            ScanLine.Scanline(Reta.getImgDta(), pol);
            Reta.DesalocarBitmap(ret);
            pictureBox.Image = ret;
            imgBmp = ret;
        }

        /*Controles*/
        private void BtnCarregar_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos obj (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string arquivo = openFileDialog.FileName;

                if (File.Exists(arquivo))
                {
                    EstadoInicial();

                    int i;
                    String linha;
                    String[] cel = new String[10];
                    String[] aux = new String[3];
                    No no = null;
                    No ini = null;

                    try
                    {
                        using (FileStream fs = new FileStream(arquivo, FileMode.Open))
                        {
                            StreamReader sr = new StreamReader(fs);
                            while ((linha = sr.ReadLine()) != null)
                            {
                                if (linha.Substring(1, 1) == " ")
                                {
                                    cel = linha.Split(' ');

                                    if (cel[0] == "v")
                                    {
                                        for (i = 1; i <= 3; i++)
                                            cel[i] = cel[i].Replace('.', ',');

                                        lVertOriginais.Add(new Pontos(cel[1], cel[2], cel[3]));
                                        lVertAtual.Add(new Pontos(cel[1], cel[2], cel[3]));
                                    }
                                    else
                                    if (cel[0] == "f")
                                    {
                                        for (i = 1; i < cel.Length && !cel[i].Equals(" "); i++)
                                        {
                                            aux = cel[i].Split('/');

                                            if (ini == null)//-1 pra comecar de 0
                                                no = ini = new No(Convert.ToInt32(aux[0]) - 1, null);
                                            else
                                            {
                                                no.setProx(new No(Convert.ToInt32(aux[0]) - 1, null));
                                                no = no.getProx();
                                            }
                                        }

                                        ini.setCount(i);
                                        lFace.Add(ini);
                                        ini = null;
                                    }
                                }
                            }
                        }

                        Reta.HeightWidth(imgBmp);
                        PontoCentral(true);//Centro da tela
                        Transladar(ctrX, ctrY, 0);
                        MultiplicarPontos();
                        Desenhar();
                        BloqueioDeOpcoes(true);
                        AtualizarCor();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            BloqueioDeOpcoes(false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                btnCtrl = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            btnCtrl = false;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (!ctrClick)
            {
                mx = e.X;
                my = e.Y;
                ctrClick = !ctrClick;

                if (btnCtrl)
                    pcX = -1;
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            /*Executa a acao mesmo sem soltar*/
            if (ctrClick && btnCtrl)
            {
                int dx = (e.X - mx);
                int dy = (e.Y - my);

                if(Math.Abs(dx) > 20 || Math.Abs(dy) > 20)
                {
                    Rotacionar(dx, dy, 0);
                    MultiplicarPontos();
                    Desenhar();

                    mx = e.X;
                    my = e.Y;
                }
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (ctrClick)
            {
                int dx = (e.X - mx);
                int dy = (e.Y - my);

                if (!btnCtrl)
                {
                    Transladar(dx, dy, 0);
                }
                else
                {
                    Rotacionar(dx, dy, 0);
                }

                MultiplicarPontos();
                Desenhar();

                ctrClick = !ctrClick;

                pcX = -1;
            }
        }

        private void MouseWheel(object sender, MouseEventArgs e)
        {
            if (btnCtrl)
            {
                if (e.Delta > 0)
                    Rotacionar(0, 0, -10);
                else
                    Rotacionar(0, 0, 10);

                MultiplicarPontos();
                Desenhar();
            }
            else
            {
                PontoCentral(false);//Centro da imagem
                Transladar(-1 * pcX, -1 * pcY, 0);

                if (e.Delta > 0)
                {
                    Escala(0.5, 0.5, 0.5);
                }
                else
                {
                    Escala(1.5, 1.5, 1.5);
                }

                Transladar(pcX, pcY, 0);
                MultiplicarPontos();
                Desenhar();

                pcX = pcY = -1;
            }
        }

        private void RbFrontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFrontal.Checked)
            {
               Desenhar(); 
            }
        }

        private void RbSuperior_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSuperior.Checked)
            {
                Desenhar();
            }
        }

        private void RbLateral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLateral.Checked)
            {
                Desenhar();
            }
        }

        private void RbCabinet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCabinet.Checked)
            {
                Desenhar();
            }
        }

        private void RbCavaleira_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCavaleira.Checked)
            {
                Desenhar();
            }
        }

        private void CbBackFaceCulling_CheckedChanged(object sender, EventArgs e)
        {
            Desenhar();
        }

        private void BtnColorir_Click(object sender, EventArgs e)
        {
            if (btnColorir.Text.Equals("Colorir"))
            {
                btnColorir.Text = "Remover cor";
                Scanline();               
            }
            else
                btnColorir.Text = "Colorir";

        }

        private void BtnCorAtual_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                btnCorAtual.BackColor = MyDialog.Color;
                r = MyDialog.Color.R;
                g = MyDialog.Color.G;
                b = MyDialog.Color.B;

                AtualizarCor();
                Scanline();
            } 
        }
    }
}
