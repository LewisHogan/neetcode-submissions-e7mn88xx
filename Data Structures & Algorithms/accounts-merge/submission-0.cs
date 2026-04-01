public class DSU
{
    int[] Parents;

    public DSU(int n)
    {
        Parents = new int[n];
        for (var i = 0; i < n; i++)
        {
            Parents[i] = i;
        }
    }

    public int FindParent(int i)
    {
        while (Parents[i] != Parents[Parents[i]]) Parents[i] = Parents[Parents[i]];
        return Parents[i];
    }

    public void Union(int u, int v)
    {
        var rootU = FindParent(u);
        var rootV = FindParent(v);

        if (rootU != rootV)
        {
            Parents[rootV] = Parents[rootU];
        }
    }
}

public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        var dsu = new DSU(accounts.Count);

        var accountNames = new Dictionary<int, string>();
        var emailsToIds = new Dictionary<string, int>();

        var id = 0;
        foreach (var account in accounts)
        {
            if (account is [var name, .. var emails])
            {
                accountNames[id] = name;
                foreach (var email in emails)
                {
                    if (!emailsToIds.ContainsKey(email))
                    {
                        emailsToIds[email] = id;
                    }
                    else
                    {
                        dsu.Union(emailsToIds[email], id);
                    }
                }
            }
            id++;
        }

        var emailsGroupedById = emailsToIds
            .GroupBy(entry => dsu.FindParent(entry.Value))
            .ToDictionary(
                grp => grp.Key,
                grp => grp.Select(e => e.Key)
            );
        
        var results = new List<List<string>>();
        foreach (var (accountId, emails) in emailsGroupedById)
        {
            var accountDetails = new List<string>();
            accountDetails.Add(accountNames[accountId]);
            accountDetails.AddRange(emails.OrderBy(email => email));
            results.Add(accountDetails);
        }

        return results;
    }
}