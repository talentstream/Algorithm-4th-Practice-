class WeightedQuickUnionUF
{
    private int[] parent;
    private int[] weight;
    private int count;

    public WeightedQuickUnionUF(int n)
    {
        count = n;
        parent = new int[n];
        weight = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            weight[i] = 1;
        }
    }

    public int Count()
    {
        return count;
    }

    public int Find(int p)
    {
        if (p < 0 || p >= parent.Length)
            return -1;
        int root = p;
        while (root != parent[root])
            root = parent[root];
        //尽管是带权树也是一模一样的写法
        while (p != root)
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
        if (weight[rootP] < weight[rootQ])
        {
            parent[rootP] = rootQ;
            weight[rootQ] += weight[rootP];
        }
        else
        {
            parent[rootQ] = rootP;
            weight[rootP] += weight[rootQ];
        }
    }
}