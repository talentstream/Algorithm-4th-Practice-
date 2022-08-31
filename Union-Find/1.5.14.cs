class WeightedQuickUnionByHeightUF
{
    private int[] parent;
    private int[] height;
    private int count;

    public WeightedQuickUnionByHeightUF(int n)
    {
        parent = new int[n];
        height = new int[n];
        count = n;
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            height[i] = 0;
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
        while (p != parent[p])
            p = parent[p];
        return p;
    }

    public bool Connected(int p,int q)
    {
        return Find(p) == Find(q);
    }

    public void Union(int p,int q)
    {
        int i = Find(p);
        int j = Find(q);
        if (i == j || i == -1 || j == -1)
            return;
        //根据树高进行权重排区别仅仅在这里
        //谁的树高大谁当父亲
        //如果一样的话就随便，但是深度肯定会+1
        if (height[i] < height[j])
            parent[i] = j;
        else if (height[i] > height[j])
            parent[j] = i;
        else
        {
            parent[i] = j;
            height[j] ++;
        }
        count--;
    }
}
