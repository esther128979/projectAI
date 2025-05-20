// import React, { useState } from "react";
// import {
//   Card,
//   Avatar,
//   Typography,
//   Button,
//   IconButton,
//   Collapse,
//   Box,
//   List,
//   ListItem,
//   ListItemIcon,
//   ListItemText,
// } from "@mui/material";

// import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
// import ExpandLessIcon from "@mui/icons-material/ExpandLess";
// import PhoneIcon from "@mui/icons-material/Phone";
// import EmailIcon from "@mui/icons-material/Email";
// import HomeIcon from "@mui/icons-material/Home";
// import WcIcon from "@mui/icons-material/Wc";

// import { User, Gender } from "../../models/User";
// import { Order } from "../../models/Order";
// import OrdersModal from "../OrdersModal/OrdersModal";

// interface UserCardProps {
//   user: User & { ProfileImageUrl?: string };
//   getOrders: (userId: number) => Promise<Order[]>;
// }

// export function UserCard({ user, getOrders }: UserCardProps) {
//   const [expanded, setExpanded] = useState(false);
//   const [ordersDialogOpen, setOrdersDialogOpen] = useState(false);
//   const [orders, setOrders] = useState<Order[]>([]);

//   const handleExpandClick = () => setExpanded(!expanded);
//   const handleShowOrders = async () => {
//     const data = await getOrders(user.Id);
//     setOrders(data);
//     setOrdersDialogOpen(true);
//   };

//   const fullName = user.Name;
//   const avatarLetter = fullName ? fullName[0] : "?";

//   const mainColor = "#008B8B"; // טורקיז כהה
//   const lightText = "#ffffff";
//   const secondaryText = "#d0f0f0";

//   return (
//     <>
//       <Card
//         sx={{
//           width: 300,
//           padding: 3,
//           borderRadius: 3,
//           backgroundColor: mainColor,
//           color: lightText,
//           boxShadow: "0 4px 12px rgba(0,0,0,0.3)",
//           display: "flex",
//           flexDirection: "column",
//           alignItems: "center",
//           textAlign: "center",
//         }}
//       >
//         {user.ProfileImageUrl ? (
//           <Avatar
//             src={user.ProfileImageUrl}
//             sx={{ width: 80, height: 80, mb: 2 }}
//           />
//         ) : (
//           <Avatar
//             sx={{
//               width: 80,
//               height: 80,
//               mb: 2,
//               bgcolor: "#006666",
//               fontSize: 32,
//             }}
//           >
//             {avatarLetter}
//           </Avatar>
//         )}

//         <Typography variant="h6" fontWeight="bold">
//           {user.Name}
//         </Typography>

//         <Box sx={{ mb: 2 }}>

//           <Box sx={{ display: "flex", alignItems: "center", justifyContent: "center", gap: 1 }}>
//             <PhoneIcon fontSize="small" />
//             <Typography variant="body2">{user.Phone}</Typography>
//           </Box>
//           <Box sx={{ display: "flex", alignItems: "center", justifyContent: "center", gap: 1, mb: 1 }}>
//             <EmailIcon fontSize="small" />
//             <Typography variant="body2">{user.Email}</Typography>
//           </Box>
//         </Box>

//         <Collapse
//           in={expanded}
//           timeout="auto"
//           unmountOnExit
//           sx={{ mt: 0, pt: 0, mb: 1 }} // מרווח מינימלי כלפי מטה, ללא מרווח כלפי מעלה
//         >
//           <Box sx={{ display: "flex", justifyContent: "center", mt: -1 }}>
//             <List dense sx={{ width: "fit-content" }}>
//               {user.Address && (
//                 <ListItem sx={{ color: lightText }}>
//                   <ListItemIcon>
//                     <HomeIcon sx={{ color: lightText }} />
//                   </ListItemIcon>
//                   <ListItemText primary={user.Address} />
//                 </ListItem>
//               )}
//               <ListItem sx={{ color: lightText }}>
//                 <ListItemIcon>
//                   <WcIcon sx={{ color: lightText }} />
//                 </ListItemIcon>
//                 <ListItemText primary={user.Gender === Gender.female ? "נקבה" : "זכר"} />
//               </ListItem>
//             </List>
//           </Box>
//         </Collapse>
//         <Box sx={{ display: "flex", gap: 1, width: "100%", justifyContent: "center" }}>
//           <Button
//             variant="contained"
//             onClick={handleShowOrders}
//             sx={{
//               backgroundColor: "#00b3b3",
//               color: "white",
//               textTransform: "none",
//               borderRadius: 2,
//               px: 3,
//               "&:hover": {
//                 backgroundColor: "#00cccc",
//               },
//             }}
//           >
//             הצג הזמנות
//           </Button>

//           <IconButton onClick={handleExpandClick} sx={{ color: "white" }}>
//             {expanded ? <ExpandLessIcon /> : <ExpandMoreIcon />}
//           </IconButton>
//         </Box>


//       </Card>

//       <OrdersModal
//         isOpen={ordersDialogOpen}
//         onClose={() => setOrdersDialogOpen(false)}
//         orders={orders}
//       />
//     </>
//   );
// }
import React, { useState } from "react";
import {
  Card,
  Avatar,
  Typography,
  Button,
  IconButton,
  Collapse,
  Box,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import ExpandLessIcon from "@mui/icons-material/ExpandLess";
import PhoneIcon from "@mui/icons-material/Phone";
import EmailIcon from "@mui/icons-material/Email";
import HomeIcon from "@mui/icons-material/Home";
import WcIcon from "@mui/icons-material/Wc";

import { User, Gender } from "../../../models/User";
import { Order } from "../../../models/Order";
import { MovieObject } from "../../../models/Movie";
import OrdersModal from "../../../components/userComponents/OrdersModal/OrdersModal";

interface UserCardProps {
  user: User & { ProfileImageUrl?: string };
  getOrders: (userId: number) => Promise<Order[]>;
}

export function UserCard({ user, getOrders }: UserCardProps) {
  const [expanded, setExpanded] = useState(false);
  const [ordersDialogOpen, setOrdersDialogOpen] = useState(false);
  const [orders, setOrders] = useState<Order[]>([]);

  const handleExpandClick = () => setExpanded(!expanded);
  const handleShowOrders = async () => {
    const data = await getOrders(user.Id);
    setOrders(data);
    setOrdersDialogOpen(true);
  };

  const fullName = user.Name;
  const avatarLetter = fullName ? fullName[0] : "?";

  const primaryColor = "#0e7490"; // cyan-800
  const lightBackground = "rgba(255, 255, 255, 0.9)";
  const textColor = primaryColor;

  return (
    <>
      <Card
        sx={{
          width: 300,
          padding: 3,
          borderRadius: 3,
          backgroundColor: lightBackground,
          color: textColor,
          boxShadow: "0 4px 12px rgba(0,0,0,0.1)",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          textAlign: "center",
        }}
      >
        {user.ProfileImageUrl ? (
          <Avatar
            src={user.ProfileImageUrl}
            sx={{ width: 80, height: 80, mb: 2 }}
          />
        ) : (
          <Avatar
            sx={{
              width: 80,
              height: 80,
              mb: 2,
              bgcolor: primaryColor,
              fontSize: 32,
              color: "white",
            }}
          >
            {avatarLetter}
          </Avatar>
        )}

        <Typography variant="h6" fontWeight="bold" sx={{ color: primaryColor }}>
          {user.Name}
        </Typography>

        <Box sx={{ mb: 2 }}>
          <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
            <PhoneIcon fontSize="small" sx={{ color: primaryColor }} />
            <Typography variant="body2" sx={{ color: primaryColor, whiteSpace: "nowrap" }}>
              {user.Phone}
            </Typography>
          </Box>

          <Box sx={{ display: "flex", alignItems: "center", gap: 1, mb: 1 }}>
            <EmailIcon fontSize="small" sx={{ color: primaryColor }} />
            <Typography variant="body2" sx={{ color: primaryColor, whiteSpace: "nowrap" }}>
              {user.Email}
            </Typography>
          </Box>

        </Box>

        <Collapse in={expanded} timeout="auto" unmountOnExit sx={{ mt: 0, pt: 0, mb: 1 }}>
          <Box sx={{ display: "flex", justifyContent: "center", mt: -1 }}>
            <List dense sx={{ width: "fit-content", color: primaryColor }}>
              {user.Address && (
                <ListItem>
                  <ListItemIcon>
                    <HomeIcon sx={{ color: primaryColor }} />
                  </ListItemIcon>
                  <ListItemText primary={user.Address} />
                </ListItem>
              )}
              <ListItem>
                <ListItemIcon>
                  <WcIcon sx={{ color: primaryColor }} />
                </ListItemIcon>
                <ListItemText primary={user.Gender === Gender.female ? "נקבה" : "זכר"} />
              </ListItem>
            </List>
          </Box>
        </Collapse>

        <Box sx={{ display: "flex", gap: 1, width: "100%", justifyContent: "center" }}>
          <Button
            variant="contained"
            onClick={handleShowOrders}
            sx={{
              backgroundColor: primaryColor,
              color: "white",
              textTransform: "none",
              borderRadius: 2,
              px: 3,
              "&:hover": {
                backgroundColor: "#155e75",
              },
            }}
          >
            הצג הזמנות
          </Button>

          <IconButton onClick={handleExpandClick} sx={{ color: primaryColor }}>
            {expanded ? <ExpandLessIcon /> : <ExpandMoreIcon />}
          </IconButton>
        </Box>
      </Card>

      <OrdersModal
        isOpen={ordersDialogOpen}
        onClose={() => setOrdersDialogOpen(false)}
        orders={orders}
      />
    </>
  );
}
