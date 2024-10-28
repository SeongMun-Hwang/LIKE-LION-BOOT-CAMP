#include<iostream>
#include <deque>
#include<algorithm>
#include<cmath>
#include<climits>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	deque<int> q;
	int n;
	cin >> n;

	while (n > 0) {
		string str;
		cin >> str;

		if (str == "push_front") {
			int n;
			cin >> n;
			q.push_front(n);
		}
		if (str == "push_back") {
			int n;
			cin >> n;
			q.push_back(n);
		}
		else if (str == "pop_front") {
			if (q.empty()) cout << -1 << "\n";
			else {
				cout << q.front() << "\n";
				q.pop_front();
			}
		}
		else if (str == "pop_back") {
			if (q.empty()) cout << -1 << "\n";
			else {
				cout << q.back() << "\n";
				q.pop_back();
			}
		}
		else if (str == "size") {
			cout << q.size() << "\n";
		}
		else if (str == "empty") {
			if (q.empty()) cout << "1" << "\n";
			else cout << "0" << "\n";
		}
		else if (str == "front") {
			if (q.empty()) cout << "-1" << "\n";
			else cout << q.front() << "\n";
		}
		else if (str == "back") {
			if (q.empty()) cout << "-1" << "\n";
			else cout << q.back() << "\n";
		}
		n--;
	}
}