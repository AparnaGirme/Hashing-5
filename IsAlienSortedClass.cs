public class Solution {
    // TC = O(nk)
    // SC = O(1)
    Dictionary<char, int> map;
    public bool IsAlienSorted(string[] words, string order) {
        if(words == null || words.Length == 0){
            return true;
        }

        map = new Dictionary<char, int>();
        for(int i = 0; i< order.Length; i++){
            map.Add(order[i], i);
        }

        for(int i = 0; i< words.Length-1; i++){
            if(IsNotSorted(words[i], words[i+1])){
                return false;
            }
        }
        return true;
    }

    public bool IsNotSorted(string first, string second){
        int m = first.Length;
        int n = second.Length;
        for(int i = 0; i< m && i < n; i++){
            if(first[i] == second[i]){
                continue;
            }
            return map[first[i]] > map[second[i]];
        }

        return m > n;
    }
}