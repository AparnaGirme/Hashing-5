public class Solution {
    // TC => O(nk)
    // SC => O(n)
    int[] indegrees;
    Dictionary<char, List<char>> map;
    public string AlienOrder(string[] words) {
        if(words == null || words.Length == 0){
            return string.Empty;
        }

        indegrees = new int[26];
        map = new Dictionary<char, List<char>>();

        BuildGraph(words);

        //topological sort
        Queue<char> queue = new Queue<char>();
        StringBuilder sb = new StringBuilder();
        foreach(var kv in map){
            if(indegrees[kv.Key - 'a'] == 0){
                queue.Enqueue(kv.Key);
            }
        }

        while(queue.Count > 0){
            char current = queue.Dequeue();
            sb.Append(current);
            var list = map[current];
            if(list == null){
                continue;
            }
            foreach(var ch in list){
                indegrees[ch - 'a']--;
                if(indegrees[ch - 'a'] == 0){
                    queue.Enqueue(ch);
                }
            }
        }

        if(sb.Length != map.Count){
            return string.Empty;
        }
        return sb.ToString();
    }

    public void BuildGraph(string[] words){
        foreach(var word in words){
            for(int i = 0; i < word.Length; i++){
                map.TryAdd(word[i], new List<char>());
            }
        }

        for(int i = 0; i< words.Length-1; i++){
            string first = words[i];
            string second = words[i+1];
            int m = first.Length;
            int n = second.Length;
            if(first.StartsWith(second) && m > n){
                map.Clear();
                return;
            }
            for(int j = 0; j < m && j < n; j++){
                if(first[j] == second[j]){
                    continue;
                }
                indegrees[second[j] - 'a']++;
                map[first[j]].Add(second[j]);
                break;
            }
        }
    }
}