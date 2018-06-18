using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MHTTSX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rd = new Random();
        int[] arr;
        Button[] arrB;
        int h = 50;
        int size = 30;
        int distance = 20;

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int input=0;
            try
            {
                input = int.Parse(txtRandom.Text.Trim());
            } catch
            {
                MessageBox.Show("Giá trị không hợp lệ!");
                return;
            }
            if (input < 2 || input > 10)
            {  
                MessageBox.Show("Số phần tử từ 2 đến 10!");
                return;
            }
            arr = new int[input];
            arrB = new Button[input];
            pnlDemo.Controls.Clear();
            for(int i=0;i<input;i++)
            {
                Button btn = new Button();
                btn.Width = btn.Height = size;
                int value = rd.Next(50);
                btn.Text = value + "";
                btn.Location = new Point(distance + pnlDemo.Controls.Count*(btn.Width + distance), pnlDemo.Height / 2 - btn.Height / 2);

                pnlDemo.Controls.Add(btn);
                arr[i] = value;
                arrB[i] = btn;
           
            
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (arr == null)
            {
                MessageBox.Show("Chưa khởi tạo phần tử! Nhấp random để khởi tạo.");
                return;
            }

            if (cbChoice.SelectedIndex==-1)
            {
                cbChoice.SelectedIndex = 0;
            }
            if (cbChoice.SelectedIndex==0)//Bubble sort.
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text = "Void BubbleSort(int a[], int n) \n { \n    for (int i = 0, i < n - 1 ; i++) \n    for (int j = n - 1;j > i; j--) \n \t if(a[j] < a[j - 1]) \n \t   Swap(a[j], a[j - 1]); \n }";
                backgroundWorker1.RunWorkerAsync();
                return;
            }
            if (cbChoice.SelectedIndex==1)//Interchange sort.
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text = "void InterchangeSort(int a[], int n) \n { \n   int i, j; \n   for(i=0;i<n-1;i++) \n \t for(j=i+1;j<n;j++) \n \t    if(a[j]<a[i]) \n \t      Swap(a[i],a[j]); \n }";
                backgroundWorker2.RunWorkerAsync();
                return;
            }
            if(cbChoice.SelectedIndex==2)
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text = "void Selection(int a[], int n) \n { \n  for (int i = 0; i < n - 1; i++) \n  { \n    int min = i; \n    for (int j = i + 1; j < n; j++) \n    { \n \t if (a[min] > a[j])\n \t min = j; \n    } \n    if (i != min) \n \t Swap(a[i], a[min]); \n   } \n}";
                backgroundWorker3.RunWorkerAsync();
                return;
            }



            if (cbChoice.SelectedIndex==3)//Quick sort.
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text = "void QuickSort(int[] a,int start, int end) \n { \n   int i, j, temp, mid; \n   mid = a[(start + end) / 2]; \n   i = start; \n   j = end; \n   do{ \n \t while (a[i]<mid) i++; \n \t while(a[j]>mid) j--; \n \t  if(i<=j) \n \t  { \n \t    Swap(arr[i],arr[j]);\n \t    i++; \n \t    j--; \n \t   } \n     }while(i<j);\n     if(start<j) QuickSort(arr,start,j); \n     if(i<end)QuickSort(arr,i,end);\n}";
                backgroundWorker4.RunWorkerAsync();
                return;
            }
            if (cbChoice.SelectedIndex==4)//Insertion sort
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text = "void InsertionSort(int a[], int n) \n { \n  for (int i = 1; i < n; i++) \n  { \n    int x = a[i]; \n    int j = i; \n    while (j > 0 && a[j - 1] > x) \n    { \n \t a[j] = a[j - 1]; \n \t j--; \n    } \n    a[j] = x; \n  } \n }";
                backgroundWorker5.RunWorkerAsync();
                return;
            }

            if (cbChoice.SelectedIndex==5)//Heap sort
            {
                btnOK.Enabled = false;
                btnRandom.Enabled = false;
                rtbCode.Text="void HeapSort(int *array, int n) \n { \n  CreateHeap(array, n); \n  int heapSize, offset; \n  heapSize = n - 1; \n  for (offset = heapSize; offset >= 0; offset--) \n  { \n     Swap(arr[0],arr[HeapSize]); \n     heapSize--; \n    Heapify(array, 0, heapSize); \n   }\n }";
                backgroundWorker6.RunWorkerAsync();
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BubbleSort(arr);
        }

        private void BubbleSort(int[] arr)
        {
            int i, j;
            Status st = new Status();
            for(i=0;i<arr.Length;i++)
            {
                for (j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                        System.Threading.Thread.Sleep(10);
                        BubbleSortMove(j, j - 1);
                    }
                }
                
               
            }
        }

        private void BubbleSortMove(int p1, int p2)
        {
            Status st = new Status();
            st.P1 = p1;
            st.P2 = p2;
            st.Type = MoveType.UpDown;
            for(int i=0;i<h;i++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for(int i=0;i<w;i++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for(int i=0;i<h;i++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker1.ReportProgress(0, st);
        }

        
        
        
        
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st == null) return;
            if (st.Type==MoveType.Stop)
            {
                Button temp = arrB[st.P1];
                arrB[st.P1] = arrB[st.P2];
                arrB[st.P2] = temp;
                return;
            }
            Button button1 = arrB[st.P1];
            Button button2 = arrB[st.P2];
            if(st.Type==MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type==MoveType.RightLeft)
            {
                button1.Left -= 1;
                button2.Left += 1;
            }
            else if (st.Type==MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
            button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            InterchangeSort(arr);
        }

        private void InterchangeSort(int[] arr)
        {
            int i, j;
            Status st = new Status();
            for(i=0;i<arr.Length-1;i++)
                for(j=i+1;j<arr.Length;j++)
                if(arr[j]<arr[i])
                {
                    int temp=arr[j];
                    arr[j]=arr[i];
                    arr[i]=temp;
                    System.Threading.Thread.Sleep(10);
                    MoveInterchangeSort(j,i);
                }
        }

        private void MoveInterchangeSort(int p1, int p2)
        {
           Status st = new Status();
            st.P1=p1;
            st.P2=p2;
            st.Type=MoveType.UpDown;
            for(int i=0;i<h;i++)
            {
                backgroundWorker2.ReportProgress(0,st);
                System.Threading.Thread.Sleep(10);

            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for (int i = 0; i < w; i++)
            {
                backgroundWorker2.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker2.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker2.ReportProgress(0, st);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st==null)return;
            if (st.Type==MoveType.Stop)
            {
                Button temp=arrB[st.P2];
                arrB[st.P2]=arrB[st.P1];
                arrB[st.P1]=temp;
                return;
            }
            Button button1=arrB[st.P1];
            Button button2=arrB[st.P2];
            if (st.Type == MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type == MoveType.RightLeft)
            {
                button1.Left -= 1;
                button2.Left += 1;
            }
            else if (st.Type == MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
                button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            QuickSort(arr,0,arr.Length-1);
        }

        private void QuickSort(int[] arr,int start, int end)
        {
            int i, j, temp, mid;
            mid = arr[(start + end) / 2];
            i = start;
            j = end;
            do{
                while (arr[i]<mid) i++;
                while(arr[j]>mid) j--;
                if(i<=j)
                {
                    temp=arr[i];
                    arr[i]=arr[j];
                    arr[j]=temp;
                    QuickSortMove(i,j);
                    i++;
                    j--;
                }
            }while(i<j);
            if(start<j) QuickSort(arr,start,j);
            if(i<end)QuickSort(arr,i,end);
            
        }

        private void QuickSortMove(int p1, int p2)
        {
            Status st = new Status();
            st.P1 = p1;
            st.P2 = p2;
            st.Type = MoveType.UpDown;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker4.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);

            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for (int i = 0; i < w; i++)
            {
                backgroundWorker4.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker4.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker4.ReportProgress(0, st);
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st == null) return;
            if (st.Type == MoveType.Stop)
            {
                Button temp = arrB[st.P2];
                arrB[st.P2] = arrB[st.P1];
                arrB[st.P1] = temp;
                return;
            }
            Button button1 = arrB[st.P1];
            Button button2 = arrB[st.P2];
            if (st.Type == MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type == MoveType.RightLeft)
            {
                button1.Left += 1;
                button2.Left -= 1;
            }
            else if (st.Type == MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
                button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            SelectionSort(arr);
        }

        private void SelectionSort(int[] a)
        {
           
	        for (int i = 0; i < a.Length-1; i++)
	        {
		        int min = i;
		        for (int j = i + 1; j < a.Length; j++)
		        {
			       if (a[min] > a[j])
			       min = j;
		        }
		        if (i != min)
                {
                   int temp=a[min];
                   a[min]=a[i];
                   a[i]=temp;
                   SelectionSortMove(i,min);
                }
	        }

        }

        private void SelectionSortMove(int p1, int p2)
        {
            Status st = new Status();
            st.P1 = p1;
            st.P2 = p2;
            st.Type = MoveType.UpDown;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker3.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);

            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for (int i = 0; i < w; i++)
            {
                backgroundWorker3.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker3.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker3.ReportProgress(0, st);
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st == null) return;
            if (st.Type == MoveType.Stop)
            {
                Button temp = arrB[st.P2];
                arrB[st.P2] = arrB[st.P1];
                arrB[st.P1] = temp;
                return;
            }
            Button button1 = arrB[st.P1];
            Button button2 = arrB[st.P2];
            if (st.Type == MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type == MoveType.RightLeft)
            {
                button1.Left += 1;
                button2.Left -= 1;
            }
            else if (st.Type == MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
                button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            InsertionSort(arr);
        }

        private void InsertionSort(int[] arr)
        {
            int j, temp;
            for (int i = 1; i < arr.Length; i++)
            {
                j = i;
                temp = arr[i];
                while (j > 0 && arr[j-1] > temp)
                {
                    
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    InsertionSortMove(j, j-1);
                    j--;
                }
                arr[j] = temp;
                
                
            }
        }

        private void InsertionSortMove(int p1, int p2)
        {
            Status st = new Status();
            st.P1 = p1;
            st.P2 = p2;
            st.Type = MoveType.UpDown;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker5.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);

            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for (int i = 0; i < w; i++)
            {
                backgroundWorker5.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker5.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker5.ReportProgress(0, st);
        }

        private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st == null) return;
            if (st.Type == MoveType.Stop)
            {
                Button temp = arrB[st.P2];
                arrB[st.P2] = arrB[st.P1];
                arrB[st.P1] = temp;
                return;
            }
            Button button1 = arrB[st.P1];
            Button button2 = arrB[st.P2];
            if (st.Type == MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type == MoveType.RightLeft)
            {
                button1.Left -= 1;
                button2.Left += 1;
            }
            else if (st.Type == MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
                button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            rtbCode.Text="Đồ án môn Lập Trình Trực Quan \n Lớp: IT008.I21 \n GV: Huỳnh Tuấn Anh \n Tên đề tài: Mô phỏng thuật toán sắp xếp. \n SV: Trần Mỹ Hạnh \n MSSV: 15520198";
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            HeapSort(arr);
        }

        private void HeapSort(int[] arr)
        {
            CreateHeap(arr, arr.Length);

            int heapSize, offset, temp;
            heapSize = arr.Length - 1;

            for (offset = heapSize; offset >= 0; offset--)
            {
                temp = arr[0];
                arr[0] = arr[heapSize];
                arr[heapSize] = temp;
                HeapSortMove(0, heapSize);
                heapSize--;

                Heapify(arr, 0, heapSize);
            }
 
        }

        private void CreateHeap(int[] arr, int length)
        {
            int offset, heapSize;
            heapSize = length - 1;

            for (offset = (length / 2); offset >= 0; offset--)
            {
                Heapify(arr, offset, heapSize);
            }
        }

        private void Heapify(int[] arr, int offset, int heapSize)
        {
            int leftNode, rightNode, largest, temp;
            leftNode = 2 * offset;
            rightNode = 2 * offset + 1;
            largest = offset;
            if (leftNode <= heapSize)
               if (arr[leftNode] > arr[offset])
                  largest = leftNode;

            if (rightNode <= heapSize)
                if (arr[rightNode] > arr[largest])
                largest = rightNode;

            if (largest != offset)
            {
                temp = arr[offset];
                arr[offset] = arr[largest];
                arr[largest] = temp;
                HeapSortMove(offset, largest);
                Heapify(arr, largest, heapSize);
            }
        }

        private void HeapSortMove(int p1, int p2)
        {
            Status st = new Status();
            st.P1 = p1;
            st.P2 = p2;
            st.Type = MoveType.UpDown;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker6.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);

            }
            st.Type = MoveType.RightLeft;
            int w = Math.Abs(p1 - p2) * (size + distance);
            for (int i = 0; i < w; i++)
            {
                backgroundWorker6.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.DownUp;
            for (int i = 0; i < h; i++)
            {
                backgroundWorker6.ReportProgress(0, st);
                System.Threading.Thread.Sleep(10);
            }
            st.Type = MoveType.Stop;
            backgroundWorker6.ReportProgress(0, st);
        }

        private void backgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status st = e.UserState as Status;
            if (st == null) return;
            if (st.Type == MoveType.Stop)
            {
                Button temp = arrB[st.P2];
                arrB[st.P2] = arrB[st.P1];
                arrB[st.P1] = temp;
                return;
            }
            Button button1 = arrB[st.P1];
            Button button2 = arrB[st.P2];
            if (st.Type == MoveType.UpDown)
            {
                button1.Top += 1;
                button2.Top -= 1;
            }
            else if (st.Type == MoveType.RightLeft)
            {
                button1.Left += 1;
                button2.Left -= 1;
            }
            else if (st.Type == MoveType.DownUp)
            {
                button1.Top -= 1;
                button2.Top += 1;
            }

        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button button in pnlDemo.Controls)
                button.ForeColor = Color.Red;
            btnRandom.Enabled = true;
            btnOK.Enabled = true;
        
        }
    }


}
