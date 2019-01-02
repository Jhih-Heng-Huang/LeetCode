package main

import "fmt"

func twoSum(nums []int, target int) []int {
	// find the two indexs that their summation is equal to the target value
	for i := 0; i < len(nums); i++ {
		for j := i + 1; j < len(nums); j++ {
			if nums[i] + nums[j] == target {
				return []int {i, j}
			}
		}
	}

	return []int {}
}

func main()  {
	fmt.Println("Hello")
}