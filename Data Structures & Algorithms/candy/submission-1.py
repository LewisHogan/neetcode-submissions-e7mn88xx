class Solution:
    def candy(self, ratings: List[int]) -> int:
        candies = [1 for _ in ratings]

        def get_higher_rated(candidates: List[int]):
            higher_rated = set()
            for i in candidates:
                rating = ratings[i]
                if i < len(ratings) - 1 and rating > ratings[i + 1]:
                    if candies[i] <= candies[i + 1]:
                        higher_rated.add(i)
                if i > 0 and rating > ratings[i - 1]:
                    if candies[i] <= candies[i - 1]:
                        higher_rated.add(i)
            return higher_rated
        
        higher_rated = get_higher_rated(range(len(ratings)))

        while len(higher_rated) != 0:
            children_to_update = list(higher_rated)
            for i in children_to_update:
                candies[i] += 1
            higher_rated = get_higher_rated(children_to_update)

        return sum(candies)