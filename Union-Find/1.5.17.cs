//客户端代码测试
var random = new Random();
int n = random.Next(10, 15);//有多少个点
Console.WriteLine($"n = {n}");
int times = 5;//测试次数
int average = 0;
for(int i = 0; i < times; i++)
{
    var edges = ErdosRenyi.Count(n);
    Console.WriteLine($"{i} : edges is {edges}");
    average += edges;
}

Console.WriteLine($"average : {(float) average/times}");

//随机链接，测试多少次才能链接完整个集合
public class ErdosRenyi
{
    public static int Count(int n)
    {
        int edges = 0;
        var uf = new WeightedQuickUnionUF(n);
        var random = new Random();
        while(uf.count>1)
        {

            int p = random.Next(n);
            int q = random.Next(n);
            if (!uf.Connected(p, q))
                uf.Union(p, q);
            edges++;
        }
        return edges;
    }
}
class WeightedQuickUnionUF
{
    private int[] parent;
    private int[] weight;
    public int count;

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


    public int Find(int p)
    {
        if (p < 0 || p >= parent.Length)
            return -1;
        int root = p;
        while (root != parent[root])
            root = parent[root];
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
        count--;
    }
}