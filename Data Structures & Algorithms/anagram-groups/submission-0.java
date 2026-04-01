class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        var groups = Arrays.stream(strs)
            .collect(Collectors.groupingBy(s -> sort(s)));

        return new ArrayList<List<String>>(groups.values());
    }

    private String sort(String str) {
        var chars = str.toCharArray();
        Arrays.sort(chars);
        return new String(chars);
    }
}
