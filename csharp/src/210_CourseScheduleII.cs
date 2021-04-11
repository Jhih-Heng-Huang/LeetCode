/*
LeetCode: 210. Course Schedule II
*/

using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problem_210
{
	public class CourseScheduleII {
		private enum State
		{
			NonVisited,
			Visiting,
			Visited,
		}

		private class Course
		{
			public State State = State.NonVisited;
			public List<int> Requires = new List<int>();
		}

		public int[] FindOrder(int numCourses,
			int[][] prerequisites)
		{
			if (numCourses == 0)
				return new int[]{};
			
			var courses = _GenCourses(numCourses, prerequisites);
			var orders = new List<int>();

			for (int i = 0; i < courses.Length; ++i)
			{
				var subOrders = new List<int>();
				if (_IsNotVisited(courses[i]) &&
					!_TryToTravel(i, courses, subOrders))
					return new int[]{};
				orders.AddRange(subOrders);
			}

			return orders.ToArray();
		}

		private Course[] _GenCourses(int num, int[][] edges)
		{
			var courses = new Course[num];
			for (int i = 0; i < num; ++i)
				courses[i] = new Course();

			foreach (var edge in edges)
			{
				var i = edge[0];
				var j = edge[1];
				courses[i].Requires.Add(j);
			}

			return courses;
		}

		private bool _IsNotVisited(Course course)
			=> course.State == State.NonVisited;

		private bool _IsVisiting(Course course)
		{
			return course.State == State.Visiting;
		}

		private bool _TryToTravel(int i, Course[] courses, List<int> orders)
		{
			if (_IsVisiting(courses[i])) return false;
			if (!_IsNotVisited(courses[i])) return true;

			courses[i].State = State.Visiting;
			foreach (var next in courses[i].Requires)
			{
				if (!_TryToTravel(next, courses, orders))
					return false;
			}
			courses[i].State = State.Visited;
			orders.Add(i);
			return true;
		}
	}
}
