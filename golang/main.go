package main

import "fmt"

// make a fast two sum function
func TwoSum(nums []int, target int) []int {
	// store nums[i] in map for checking if the value of nums[i] is equal to target - nums[j]
	m := make(map[int]int)

	for i := 0; i < len(nums); i++ {
		diffValue := target - nums[i]
		switch index, existed := m[diffValue]; existed {
		case true:
			return []int{index, i}
		default:
			m[nums[i]] = i
		}
	}

	return []int{}
}

func main()  {
	fmt.Println("Hello")
}