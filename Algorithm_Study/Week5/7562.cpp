#include <iostream>
#include <vector>
#include <queue>
using namespace std;

pair<int, int> knightMove[] = {
	{2,1},{2,-1},{-2,1},{-2,-1},
	{1,2},{1,-2},{-1,2},{-1,-2},
};

int KnightMove(int length, pair<int, int> startPos, pair<int, int> destinationPos) {
	vector<vector<int>> v(length, vector<int>(length, -1));
	queue<pair<int, int>> q;
	q.push(startPos);
	v[startPos.first][startPos.second] = 0;

	while (!q.empty()) {
		int x = q.front().first;
		int y = q.front().second;
		q.pop();

		if (x == destinationPos.first && y == destinationPos.second) {
			return v[x][y];
		}
		for (int i = 0; i < 8; i++) {
			int nextX = x + knightMove[i].first;
			int nextY = y + knightMove[i].second;

			if (nextX >= 0 && nextY >= 0 && nextX < length && nextY < length && v[nextX][nextY] == -1) {
				v[nextX][nextY] = v[x][y] + 1;
				q.push({ nextX,nextY });
			}
		}
	}
	return -1;
}

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	int n;
	cin >> n;
	for (int i = 0; i < n; i++) {
		int length;
		cin >> length;
		pair<int, int> start, target;
		cin >> start.first >> start.second;
		cin >> target.first >> target.second;
		cout << KnightMove(length, start, target) <<"\n";
	}
	return 0;
}
