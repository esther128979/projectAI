
import React from 'react';
import { User} from '../../models/User';
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";

  interface UserProfileCardProps {
   user:User
  }
  
  export function UserProfileCard({ user }: UserProfileCardProps) {
    return (
      <Card className="w-[300px] shadow-md">
        <CardHeader>
          <CardTitle>{user.Name}</CardTitle>
        </CardHeader>
        <CardContent>
          <p>📧 {user.Email}</p>
          <p>📞 {user.Phone}</p>
        </CardContent>
      </Card>
    );
  }
  