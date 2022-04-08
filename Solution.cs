public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freqMap = new Dictionary<int,int>();
        
        // Fill a frequency map
        foreach (var num in nums) {
            if (freqMap.ContainsKey(num)) {
                freqMap[num]++;
            } else {
                freqMap.Add(num, 1);
            }
        }
        
        // Create a Priority Queue
        var pqueue = new PriorityQueue<int,int>();
        
        // Fill the Priority Queue
        foreach (var item in freqMap) {
            // PriorityQueue.Dequeue returns lowest priority first so we add our most frequent as a negative value to get the behavior we want
            pqueue.Enqueue(item.Key, -item.Value);
        }
        
        // Add k items from Priority Queue into the Result
        var result = new int[k];
        for (int i = 0; i < k; i++) {
            result[i] = pqueue.Dequeue();
        }        
        
        return result;
    }
}
