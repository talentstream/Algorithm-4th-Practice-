//客户端代码，测试程序
//QuickUnionUF测试
int QUn = int.Parse(Console.ReadLine());
QuickUnionUF qu = new QuickUnionUF(QUn);
int p, q;
for(int i=0;i<=10;i++)
{
    string str = Console.ReadLine();
    p = (int)Char.GetNumericValue(str[0]);
    q = (int)Char.GetNumericValue(str[2]);
    if (qu.Connected(p, q)) continue;
    qu.Union(p, q);
}

qu.PrintParent();

//QuickFindUF测试
int QFn = int.Parse(Console.ReadLine());
QuickFindUF qf = new QuickFindUF(QFn);
for (int i = 0; i <= 10; i++)
{
    string str = Console.ReadLine();
    p = (int)Char.GetNumericValue(str[0]);
    q = (int)Char.GetNumericValue(str[2]);
    if (qf.Connected(p, q)) continue;
    qf.Union(p, q);
}

qf.PrintId();

/*输入测试
10 
4 3 
3 8 
6 5 
9 4 
2 1 
8 9 
5 0 
7 2 
6 1 
1 0 
6 7
10 
4 3 
3 8 
6 5 
9 4 
2 1 
8 9 
5 0 
7 2 
6 1 
1 0 
6 7
 */
//QuickUnionUF类，降低了Union步骤的时间复杂度到1
class QuickUnionUF
{
    private int[] parent;
    private int count;

    public QuickUnionUF(int n)
    {
        parent = new int[n];
        count = n;
        for (int i = 0; i < n; i++)
            parent[i] = i;
    }

    public int Count()
    {
        return count;
    }

    public int Find(int p)
    {
        if (p < 0 || p >= parent.Length)
            return -1;
        while (p != parent[p])
            p = parent[p];
        return p;
    }

    public bool Connected(int p, int q)
    {
        return Find(p) == Find(q);
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ || rootP == -1 || rootQ == -1)
            return;
        parent[rootP] = rootQ;
        count--;
    }

    public void PrintParent()
    {
        Console.WriteLine();
        for (int i = 0; i < parent.Length; i++)
            Console.WriteLine($"{i} . {parent[i]} . {Find(i)}");
    }
}
//QuickFindUF类，Find的时间复杂度为1
class QuickFindUF
{
    private int[] id;
    private int count;

    public QuickFindUF(int n)
    {
        id = new int[n];
        count = n;
        for (int i = 0; i < n; i++)
            id[i] = i;
    }

    public int Find(int p)
    {
        return id[p];
    }

    public bool Connected(int p, int q)
    {
        return Find(p) == Find(q);
    }

    public void Union(int p, int q)
    {
        int pId = Find(p);
        int qId = Find(q);

        if (pId == qId)
            return;

        for (int i = 0; i < id.Length; i++)
            if (id[i] == pId) id[i] = qId;
        count--;
    }

    public void PrintId()
    {
        Console.WriteLine();
        for (int i = 0; i < id.Length; i++)
            Console.WriteLine($"{i} . {id[i]}");
    }
}
