import { useState } from "react";
import { Card, CardHeader, CardTitle, CardContent } from "../../ui/card";
import { User, Gender } from "../../models/User";
import { CardButton } from "../../ui/card";
import './UserProfileCard.scss';

interface UserProfileCardProps {
  user: User;
  onShowOrders?: (userId: number) => void;
}

export function UserProfileCard({ user, onShowOrders }: UserProfileCardProps) {
  const [showDetails, setShowDetails] = useState(false);

  return (
    <Card className="user-card">
      <CardHeader className="mb-3">
        <CardTitle className="text-2xl font-bold text-teal-800 tracking-wide text-center">
          {user.Name}
        </CardTitle>
      </CardHeader>

      <CardContent className="text-sm text-gray-800 space-y-2">
        <div className="space-y-1">
          <p>📧 <span className="text-teal-700">{user.Email}</span></p>
          <p>📞 <span className="text-teal-700">{user.Phone}</span></p>
        </div>

        {showDetails && (
          <div className="mt-3 space-y-2 border-t border-dashed border-teal-200 pt-3">
            {user.Address && (
              <p>🏠<span className="text-teal-700">{user.Address}</span></p>
            )}
            <p>🧾<span className="text-teal-700">{user.Gender === Gender.female ? 'נקבה' : 'זכר'}</span></p>
            <p>🆔<span className="text-teal-700">{user.Id}</span></p>
          </div>
        )}
        <div className="mt-5 flex justify-between gap-3 font-bold">
          <button
            className="text-teal-700 underline hover:text-teal-900 transition cursor-pointer"
            onClick={() => setShowDetails(!showDetails)}
          >
            {showDetails ? "הסתר פרטים" : "ראה עוד"}
          </button>
          <CardButton
            className="bg-teal-700 text-white px-4 py-2 rounded hover:bg-teal-800 font-bold"
            onClick={() => {
              console.log("הזמנות של המשתמש עם ID:", user.Id);
              onShowOrders?.(user.Id);
            }}
          >
            הצג הזמנות
          </CardButton>
        </div>
      </CardContent>
    </Card>

  );
}
