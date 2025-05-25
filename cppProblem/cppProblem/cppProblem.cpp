#include <iostream>
#include <cmath>
#include <vector>
#include "Vector.hpp"

#define PI 3.14159265 // 𝝅 값

using namespace std;

class Object
{
private:
	Vector3 position;
	Vector3 forward;
	Vector3 right;
	Vector3 up;
	float viewAngle;

public:
	// 생성자
	Object(const Vector3& pos, const Vector3& fwd, float angle = 120.0f)
		: position(pos), forward(fwd.Normalized()), viewAngle(angle)
	{
		Vector3 worldUp(0.0f, 1.0f, 0.0f);

		right = forward.Cross(worldUp).Normalized();

		up = right.Cross(forward).Normalized();
	}

	// TASK 1: 타겟 방향으로의 단위 벡터 계산
	Vector3 GetDirectionToTarget(const Vector3& targetPosition) const
	{
		// 여기에 코드를 작성하세요
		// 힌트: 타겟 위치 - 현재 위치를 계산한 후 정규화
		Vector3 targetPositionRelative = targetPosition - position; // 타겟 위치 - 현재 위치
		Vector3 normalized = targetPositionRelative.Normalized(); // 정규화
		if (normalized.x == 0 && normalized.y == 0 && normalized.z == 0)
			normalized.z = 1.0f; // 정규화된 값이 (0, 0, 0) 일 시 (0, 0, 1)로 지정
		return normalized; // 정규화 된 벡터 반환
	}

	// TASK 2: 현재 위치와 타겟 간의 정확한 거리 계산
	float GetDistanceToTarget(const Vector3& targetPosition) const
	{
		// 여기에 코드를 작성하세요
		// 힌트: 두 점 사이의 거리 공식을 사용
		Vector3 targetPositionRelative = targetPosition - position; // 현재 위치에 대한 타겟의 상대 위치
		return targetPositionRelative.Length(); // 상대 위치 기반 거리 반환
	}

	// TASK 3: 타겟이 오브젝트 기준 왼쪽/오른쪽 판별
	// 반환값: 1(오른쪽), -1(왼쪽), 0(정확히 같은 선상)
	int IsTargetOnRight(const Vector3& targetPosition) const
	{
		// 여기에 코드를 작성하세요
		// 힌트: 외적을 사용하여 방향 판별
		Vector3 targetPositionRelative = targetPosition - position; // 현재 위치에 대한 타겟의 상대 위치
		Vector3 cross = forward.Cross(targetPositionRelative.Normalized());
		// 상대 위치 기반 정규화, 정규화 기반 외적 계산 (-1 =< x =< 1)
		if (cross.y < 0) // 0 보다 작으면 왼쪽
			return -1;
		else if (cross.y > 0) // 0 보다 크면 오른쪽
			return 1;
		else // 0 이면 정확히 같은 선상
			return 0; // 0
	}

	// TASK 4: 타겟이 시야각 내에 있는지 판별
	bool IsTargetInViewAngle(const Vector3& targetPosition) const
	{
		// 여기에 코드를 작성하세요
		// 힌트: 내적을 사용하여 각도 계산
		if ((position.x == targetPosition.x && position.y == targetPosition.y && position.z == targetPosition.z))
			return true; // 현재 위치와 타겟의 위치가 같을 시 true 반환
		Vector3 targetPositionRelative = targetPosition - position; // 현재 위치에 대한 타겟의 상대 위치
		double dot = forward.Dot(targetPositionRelative.Normalized()); // 상대 위치 기반 내적 계산 (cos𝛳)
		double cosAngle = cos( (double)viewAngle * PI / 360); // 시야각 기반 cos 연산 (cos𝛳)
		if (dot >= cosAngle) // cos 그래프 기반 dot이 cosAngle보다 크거나 같으면 시야각 내에 타겟 위치
			return true; // 타겟이 시야각 내에 존재 시 true 반환
		else 
			return false; // 존재 안할 시 false 반환
	}

	const Vector3& GetPosition() const { return position; }

	const Vector3& GetForward() const { return forward; }

	void SetPosition(const Vector3& pos) { position = pos; }

	void SetForward(const Vector3& fwd)
	{
		forward = fwd.Normalized();

		Vector3 worldUp(0.0f, 1.0f, 0.0f);
		right = forward.Cross(worldUp).Normalized();
		up = right.Cross(forward).Normalized();
	}
};

void TestVectorOperations()
{
	std::cout << "===== 벡터 연산 테스트 =====" << std::endl;

	Vector3 v1(1.0f, 2.0f, 3.0f);
	Vector3 v2(4.0f, 5.0f, 6.0f);

	// TASK 1 : 벡터 출력
	{
		cout << "v1: (" << v1.x << ", " << v1.y << ", " << v1.z << ")\n";
		cout << "v2: (" << v2.x << ", " << v2.y << ", " << v2.z << ")\n";
	}

	Vector3 sum = v1 + v2;
	Vector3 diff = v1 - v2;
	Vector3 scaled = v1 * 2.0f;

	// TASK 2 : 벡터의 덧셈, 뺄셈, 곱셈(스칼라 곱)을 출력
	{
		cout << "v1 + v2: (" << sum.x << ", " << sum.y << ", " << sum.z << ")\n";
		cout << "v1 - v2: (" << diff.x << ", " << diff.y << ", " << diff.z << ")\n";
		cout << "v1 * 2: (" << scaled.x << ", " << scaled.y << ", " << scaled.z << ")\n";
	}

	float dot = v1.Dot(v2);
	Vector3 cross = v1.Cross(v2);
	float length = v1.Length();

	// TASK 3 : 벡터의 외적, 내적, 길이를 출력
	{
		cout << "v1 ∙ v2: " << dot << '\n';
		cout << "v1 × v2: (" << cross.x << ", " << cross.y << ", " << cross.z << ")\n";
		cout << "길이(v1): " << length << '\n';
	}

	Vector3 normalized = v1.Normalized();

	// TASK 4 : 정규화된 벡터와 길이를 출력
	{
		cout << "정규화(v1): (" << normalized.x << ", " << normalized.y << ", " << normalized.z << ")\n";
		cout << "정규화된 벡터의 길이: " << normalized.Length() << '\n';
	}
}

void TestTargetTracking()
{
	std::cout << "\n===== 타겟 추적 테스트 =====" << std::endl;

	Object obj(Vector3(0.0f, 0.0f, 0.0f), Vector3(0.0f, 0.0f, 1.0f));

	Vector3 targets[] =
	{
		Vector3(5.0f, 0.0f, 5.0f),
		Vector3(-5.0f, 0.0f, 5.0f),
		Vector3(0.0f, 0.0f, -10.0f),
		Vector3(0.0f, 0.0f, 10.0f),
		Vector3(0.0f, 0.0f, 0.0f)
	};

	for (const auto& target : targets)
	{
		std::cout << "\n대상 위치: (" << target.x << ", " << target.y << ", " << target.z << ")" << std::endl;

		// TASK 1: 방향 벡터 계산 테스트
		// 여기에 코드를 추가하세요
		Vector3 normalized = obj.GetDirectionToTarget(target); // 방향 벡터 계산, 반환
		cout << "방향 벡터: (" << normalized.x << ", " << normalized.y << ", " << normalized.z << ")" << endl; 
		cout << "방향 벡터 길이 : " << normalized.Length() << '\n';

		// TASK 2: 거리 계산 테스트
		// 여기에 코드를 추가하세요

		cout << "거리 : " << obj.GetDistanceToTarget(target) << '\n'; 

		// TASK 3: 왼쪽/오른쪽 판별 테스트
		// 여기에 코드를 추가하세요
		switch (obj.IsTargetOnRight(target))
		{
			case -1:
				cout << "타겟 위치 : 왼쪽\n";
				break;
			case 0:
				cout << "타겟 위치 : 정확히 같은 선상\n";
				break;
			case 1:
				cout << "타겟 위치 : 오른쪽\n";
				break;
			default:
				break;
		}
		// TASK 4: 시야각 판별 테스트
		// 여기에 코드를 추가하세요
		if(obj.IsTargetInViewAngle(target))
			cout << "시야각 내 여부: 시야 내\n";
		else
			cout << "시야각 내 여부: 시야 밖\n";
	}
}

int main()
{
	TestVectorOperations();

	TestTargetTracking();

	return 0;
}