class QuickUnionPathCompressionUF
{
    private int[] parent;
    private int count;

    public QuickUnionPathCompressionUF(int n)
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
    //在Find中进行路径压缩
    public int Find(int p)
    {
        if (p < 0 || p >= parent.Length)
            return -1;

        int root = p;
        while (root != parent[root])
            root = parent[root];
        //先拆分出当前节点和根节点
        //使当前结点的父亲直接变为根
        //然后让原本的父亲的父亲直接变为根
        //沿着树一直往上遍历到根
        while(p != root)
        {
            int newp = parent[p];
            parent[p] = root;
            p = newp;
        }
        return root;
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