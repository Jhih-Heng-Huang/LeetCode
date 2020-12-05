/*
210. Course Schedule II
*/

using System.Collections.Generic;
using System.Linq;

public class CourseScheduleII {
	private enum State {
		NonVisit,
		Visiting,
		Visited,
	}

	private class Course {
		public State VisitState = State.NonVisit;
		public bool IsValid = false;
		public List<int> Requires = new List<int>();
	}
	public int[] FindOrder(int numCourses,
						   int[][] prerequisites)
	{
		if (numCourses <= 0)
			return new int[]{};

		var courses = _GenCourses(numCourses, prerequisites);
		var orders = new List<int>();

		for (int i = 0; i < courses.Length; ++i) {
			int[] subOrders = new int[]{};

			if (_IsNonVisit(courses[i]) &&
				!_TryRecordTravelOrders(i, courses, out subOrders))
				return new int[]{};

			orders.AddRange(subOrders);
		}

		return orders.ToArray();
	}

	private Course[] _GenCourses(in int num, in int[][] edges) {
		var courses = new Course[num];

		for (int i = 0; i < num; ++i) courses[i] = new Course();

		foreach (var edge in edges) {
			var i = edge[0];
			var j = edge[1];
			courses[i].Requires.Add(j);
		}

		return courses;
	}

	private bool _IsNonVisit(in Course course) {
		return course.VisitState == State.NonVisit;
	}

	private bool _IsVisited(in Course course) {
		return course.VisitState == State.Visited;
	}

	private bool _IsVisiting(in Course course) {
		return course.VisitState == State.Visiting;
	}

	private bool _TryRecordTravelOrders(
		in int current,
		Course[] courses,
		out int[] orders)
	{
		if (_IsVisited(courses[current])) {
			orders = null;
			return courses[current].IsValid;
		}
		if (_IsVisiting(courses[current])) {
			goto Fail;
		}

		var newOrders = new List<int>();
		courses[current].VisitState = State.Visiting;

		foreach (var require in courses[current].Requires) {
			int[] subOrders = new int[]{};
			if (!_TryRecordTravelOrders(require, courses, out subOrders))
				goto Fail;

			newOrders.AddRange(subOrders);
		}
		goto Success;
	Fail:
		courses[current].VisitState = State.Visited;
		courses[current].IsValid = false;
		orders = null;
		return false;
	Success:
		courses[current].VisitState = State.Visited;
		courses[current].IsValid = true;
		newOrders.Add(current);
		orders = newOrders.ToArray();
		return true;
	}
}