class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        # Since we evalaute row by row we don't need to store
        # more then one set of row numbers, we can just clear
        # when needed
        valid_numbers = [str(i) for i in range(1, 10)]
        row_numbers = set(valid_numbers)
        column_numbers = [set(valid_numbers) for i in range(len(board))]
        square_numbers = [set(valid_numbers) for i in range(9)]

        for index in range(len(board) * len(board)):
            row_index = index // 9
            column_index = index % 9
            square_index = (row_index // 3) * 3 + (column_index // 3)

            if column_index == 0:
                row_numbers = set(valid_numbers)

            cell_value = board[row_index][column_index]
            if cell_value == '.':
                continue
            if cell_value not in row_numbers:
                return False
            if cell_value not in column_numbers[column_index]:
                return False
            if cell_value not in square_numbers[square_index]:
                return False

            row_numbers.remove(cell_value)
            column_numbers[column_index].remove(cell_value)
            square_numbers[square_index].remove(cell_value)
            
        return True