import React, { FC, useState } from "react";
import logo from 'logo.png';
import LogoutIcon from '@mui/icons-material/Logout';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import ReceiptIcon from '@mui/icons-material/Receipt';
import { AppBar, Toolbar, Button, Typography, Tab, Tabs, IconButton, Tooltip, TextField, Badge } from "@mui/material";
import { Box, Container } from "@mui/system";
import { useNavigate, Routes, Route, useLocation } from "react-router-dom";
import HomePage from "../HomePage/HomePage";
import { MovieObject, CategoryGroup, AgeGroup } from "../../../models/Movie";
import ChatIcon from '@mui/icons-material/Chat';
import CloseIcon from '@mui/icons-material/Close';
import { Paper, Collapse } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { logout } from '../../../redux/authSlice';
import { loginUser } from '../../../redux/authSlice';
import { useDispatch, useSelector } from 'react-redux';
import { selectUsername } from '../../../redux/authSlice';
import MovieListUser from '../MovieListUser/MovieListUser';
import Cart from "../../Cart/Cart"

interface AppContentProps { }


const moviesExemple: MovieObject[] = [
    {
        Id:4,
        CategoryGroup: CategoryGroup.Children,
        AgeGroup: AgeGroup.Children,
        ThereIsWoman: true,
        Duration: 90,
        AmountOfViews: 120,
        FilmProductionDate: new Date("2020-06-15"),
        Name: "The Magical Forest",
        Description: "An adventure of a young girl discovering a hidden forest.",
        Url: "https://example.com/magical-forest",
        Image: "https://mikispitzer.com/wp-content/uploads/2021/03/DSC_05652-Edit-Edit-2-300x300.jpg",
        Price: 12.99
    },
    {
                Id:7,
        CategoryGroup: CategoryGroup.Recipes,
        AgeGroup: AgeGroup.Adult,
        ThereIsWoman: false,
        Duration: 45,
        AmountOfViews: 80,
        FilmProductionDate: new Date("2018-09-20"),
        Name: "Master Chef Secrets",
        Description: "Top chefs reveal their kitchen secrets.",
        Url: "https://example.com/master-chef",
        Image: "https://mikispitzer.com/wp-content/uploads/2021/03/miki-spitzer-5-1-300x300.jpeg",
        Price: 9.99
    },
    {
                Id:8,
        CategoryGroup: CategoryGroup.Nature,
        AgeGroup: AgeGroup.Teens,
        ThereIsWoman: true,
        Duration: 60,
        AmountOfViews: 95,
        FilmProductionDate: new Date("2019-03-12"),
        Name: "Wildlife Wonders",
        Description: "A documentary exploring the wonders of wildlife.",
        Url: "https://example.com/wildlife-wonders",
        Image: "https://mikispitzer.com/wp-content/uploads/2021/03/DSC_03034-Edit-3-300x300.jpg",
        Price: 11.49
    },
    {
                Id:5,
        CategoryGroup: CategoryGroup.Plot,
        AgeGroup: AgeGroup.Adult,
        ThereIsWoman: true,
        Duration: 110,
        AmountOfViews: 150,
        FilmProductionDate: new Date("2022-01-10"),
        Name: "The Hidden Truth",
        Description: "A suspenseful thriller uncovering a deep conspiracy.",
        Url: "https://example.com/hidden-truth",
        Image: "https://mikispitzer.com/wp-content/uploads/2021/03/WhatsApp-Image-2021-03-18-at-20.28.32-4-300x300.jpeg",
        Price: 14.99
    },
    {
                Id:2,
        CategoryGroup: CategoryGroup.Children,
        AgeGroup: AgeGroup.Babies,
        ThereIsWoman: false,
        Duration: 30,
        AmountOfViews: 50,
        FilmProductionDate: new Date("2021-11-05"),
        Name: "Baby's First Adventure",
        Description: "A fun and educational animation for toddlers.",
        Url: "https://example.com/baby-adventure",
        Image: "https://mikispitzer.com/wp-content/uploads/2023/03/DJI_0599-300x300.jpg",
        Price: 7.99
    },
    {
                Id:8,
        CategoryGroup: CategoryGroup.Nature,
        AgeGroup: AgeGroup.GoldenAge,
        ThereIsWoman: true,
        Duration: 85,
        AmountOfViews: 70,
        FilmProductionDate: new Date("2017-05-30"),
        Name: "Serene Landscapes",
        Description: "A calming journey through beautiful landscapes.",
        Url: "https://example.com/serene-landscapes",
        Image: "https://mikispitzer.com/wp-content/uploads/2022/12/DSC_5202-Edit-300x300.jpg",
        Price: 10.99
    },
    {
                Id:1,
        CategoryGroup: CategoryGroup.Recipes,
        AgeGroup: AgeGroup.Adult,
        ThereIsWoman: true,
        Duration: 55,
        AmountOfViews: 100,
        FilmProductionDate: new Date("2023-02-18"),
        Name: "Vegan Delights",
        Description: "Learn to cook delicious vegan meals.",
        Url: "https://example.com/vegan-delights",
        Image: "https://mikispitzer.com/wp-content/uploads/2023/07/DSC2490-Edit-3-300x300.jpg",
        Price: 13.49
    },
    {
        Id:8,
        CategoryGroup: CategoryGroup.Plot,
        AgeGroup: AgeGroup.Teens,
        ThereIsWoman: false,
        Duration: 130,
        AmountOfViews: 200,
        FilmProductionDate: new Date("2020-08-22"),
        Name: "The Lost Treasure",
        Description: "An action-packed adventure to find a legendary treasure.",
        Url: "https://example.com/lost-treasure",
        Image: "https://mikispitzer.com/wp-content/uploads/2021/06/DSC_2724-Edit-2-300x300.jpg",
        Price: 15.99
    },
    {
                Id:8,
        CategoryGroup: CategoryGroup.Children,
        AgeGroup: AgeGroup.Children,
        ThereIsWoman: true,
        Duration: 75,
        AmountOfViews: 110,
        FilmProductionDate: new Date("2016-12-10"),
        Name: "Fairy Tale Chronicles",
        Description: "A magical journey through the world of fairy tales.",
        Url: "https://example.com/fairy-tales",
        Image: "https://mikispitzer.com/wp-content/uploads/2024/04/52-300x300.jpg",
        Price: 14.49
    },
    {
        Id:7,
        CategoryGroup: CategoryGroup.Recipes,
        AgeGroup: AgeGroup.Adult,
        ThereIsWoman: false,
        Duration: 95,
        AmountOfViews: 25,
        FilmProductionDate: new Date("2015-04-10"),
        Name: "Cooking with Grandma",
        Description: "A heartwarming look at traditional home-cooked meals.",
        Url: "https://example.com/cooking-with-grandma",
        Image: "https://mikispitzer.com/wp-content/uploads/2023/12/DSC8892-Recovered-300x300.jpg",
        Price: 9.99
    }
];

const AppContent: FC<AppContentProps> = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const dispatch = useDispatch();
    const cartCount = useSelector((state: any) => state.myCart.items.length);
    const username = useSelector(selectUsername);

    const [isChatOpen, setIsChatOpen] = useState(false);
    const [chatMessages, setChatMessages] = useState<ChatMessage[]>([]);
    const [newMessage, setNewMessage] = useState("");
    const toggleChat = () => setIsChatOpen(!isChatOpen);
    type ChatMessage = {
        text: string;
        time: string;
    };

    const handleSendMessage = () => {
        if (newMessage.trim() === "") return;

        const now = new Date();
        const timeString = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

        const newChatMessage: ChatMessage = {
            text: newMessage.trim(),
            time: timeString,
        };

        setChatMessages(prev => [...prev, newChatMessage]);
        setNewMessage("");
    };

    // הקלטה של הודעה חדשה
    const handleNewMessageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewMessage(event.target.value);
    };//רגע הניתובים של המנהל כן עובדים?
    // הפונקציה מחזירה את האינדקס של הטאב לפי הנתיב, או -1 אם לא מתאים
    const getPageFromPath = (path: string) => {
        switch (path) {
            case '/all-movies':
                return 0;
            case '/for-you':
                return 1;
            case '/about':
                return 2;
            default:
                return -1; // שום טאב לא מסומן
        }
    };

    const page = getPageFromPath(location.pathname);

    const ForYou = () => <div>במיוחד בשבילך</div>;
    // const Cart = () => <div>עגלת קניות</div>;
    const Orders = () => <div>ההזמנות שלך</div>;
    const About = () =>
        <div
            style={{
                direction: "rtl",
                textAlign: "right",
                fontFamily: "'Noto Sans Hebrew', sans-serif",
                lineHeight: 1.7,
                padding: "1.5em 2em",
                backgroundColor: "#f8fafc",
                borderRadius: 12,
                maxWidth: 800,
                margin: "8vh auto 2em", // שימי לב כאן - הוספנו margin-top יחסי
                boxShadow: "0 0 10px rgba(0,0,0,0.1)",
                color: "#3e3e3e",
            }}
        >
            <h2 style={{ fontSize: "1.6em", marginBottom: "1em" }}>
                אתר "DosFlix" – צפייה טהורה, חוויה מעוררת לב
            </h2>

            <p>
                אתר DosFlix נוסד מתוך תחושת שליחות עמוקה ונקייה: להנגיש לציבור יראי ה' –
                בני תורה, משפחותיהם ובני נוער שוחרי אמת – תכנים מובחרים המחזקים את
                הנפש, מאירים את הלב ומכוונים את האדם לדרך טובה ויציבה. זוהי במה עדינה
                וערכית, שמטרתה להעניק מענה איכותי, רוחני ונקי לעולם התוכן הדיגיטלי –
                מבלי להתפשר כהוא זה על עקרונות של צניעות, קדושה, והשפעה רוחנית חיובית.
            </p>

            <p>
                את האתר מנהלים במסירות רבה, באחריות וביראת שמיים, הזוג רפאל ונעמי קליפשטיין
                מירושלים – תלמידי חכמים, אנשי חינוך ונפשות פועלות, אשר מקדישים את
                חייהם לחיזוק דור העתיד, בהכוונה רוחנית ובליווי אישי. האתר פועל בשיתוף
                פעולה מתמיד עם רבנים מוסמכים, מחנכים ואנשי דעת תורה, וכל תוכן שבו מוגש
                לאחר בחינה רוחנית וחינוכית קפדנית.
            </p>

            <h3 style={{ marginTop: "1.5em", marginBottom: "0.7em" }}>
                עקרונות היסוד של DosFlix:
            </h3>
            <ul style={{ paddingRight: "1.2em" }}>
                <li>
                    <strong>תיאום עם דעת תורה:</strong> כל סרטון, שיעור, סדרה או קליפ נבחן
                    באמות מידה של הלכה, מוסר והשפעה חינוכית. אין קיצורי דרך.
                </li>
                <li>
                    <strong>חיזוק בלבד:</strong> אין אצלנו "סתם" בידור. כל צפייה נועדה
                    לחזק – אמונה, דרך ארץ, מוסר, שמחת חיים ותודעת שליחות.
                </li>
                <li>
                    <strong>צניעות מוחלטת:</strong> ההקפדה על תוכן נקי, צנוע ומכובד – היא
                    תנאי ראשון לכל פרסום באתר.
                </li>
                <li>
                    <strong>סביבה רגועה ומכבדת:</strong> הממשק הדיגיטלי של DosFlix מעוצב כך
                    שיסייע לריכוז, מנוחה פנימית וצפייה ללא רעשי רקע. זהו מרחב של נשימה
                    רוחנית.
                </li>
                <li>
                    <strong>ללא פרסומות, ללא הסחות דעת:</strong> כדי שהלב יוכל באמת להיפתח,
                    המרחב הווירטואלי חייב להיות מוגן, מתון ומכיל.
                </li>
            </ul>

            <h3 style={{ marginTop: "1.5em", marginBottom: "0.7em" }}>למי מיועד האתר?</h3>
            <p>
                לכל מי שמחפש תוכן מחזק – משפחות יראי שמיים, בני נוער מבקשי אמת,
                מחנכים, מדריכים, ואפילו יחידים שעומדים בפני אתגרים רוחניים – ורוצים
                להכניס קצת אור, עידוד וחום אל תוך השגרה.
            </p>

        </div>;
    // const Login = () => <div>התחברות</div>;
    const Register = () => <div>הרשמה</div>;

    const handleLogout = () => {
        dispatch(logout());
        navigate('/');
    };

    const handleChange = (event: React.SyntheticEvent, newPage: number) => {
        switch (newPage) {
            case 0: navigate('/all-movies'); break;
            case 1: navigate('/for-you'); break;
            case 2: navigate('/about'); break;
            default: break;
        }
    };


    return (
        <Box dir="rtl" sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            <AppBar position="fixed" sx={{ backgroundColor: '#fff', boxShadow: 'none' }}>
                <Toolbar sx={{ justifyContent: 'space-between', alignItems: 'center', padding: '8px 16px' }}>

                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        <Tooltip title="DosFlix">
                            <IconButton onClick={() => navigate('/')} sx={{ color: "#c1dbca" }}>
                                <img src={logo} alt="DosFlix Logo" style={{ height: 50, borderRadius: '50%' }} />
                            </IconButton>
                        </Tooltip>

                        {username && (
                            <Typography variant="subtitle1" sx={{ color: '#7a7a7a', fontWeight: 'bold' }}>
                                שלום, {username}
                            </Typography>
                        )}
                    </Box>

                    <Tabs
                        value={page >= 0 && page <= 2 ? page : false}
                        onChange={handleChange}
                        textColor="inherit"
                        TabIndicatorProps={{ style: { backgroundColor: '#7a7a7a' } }}
                        sx={{
                            '& .MuiTab-root': { color: '#666666', fontWeight: 'bold', minWidth: 90 },
                            '& .Mui-selected': { color: '#7a7a7a' },
                        }}
                    >
                        <Tab label="כל הסרטים" />
                        <Tab label="במיוחד בשבילך" />
                        <Tab label="אודות" />
                    </Tabs>

                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        <Tooltip title="ההזמנות שלך">
                            <IconButton onClick={() => navigate('/orders')} sx={{ color: "#c1dbca" }}>
                                <ReceiptIcon />
                            </IconButton>
                        </Tooltip>

                        <Tooltip title="צ'אט">
                            <IconButton onClick={toggleChat} sx={{ color: "#c1dbca" }}>
                                <ChatIcon />
                            </IconButton>
                        </Tooltip>
                        <Tooltip title="עגלת קניות">
                            <IconButton onClick={() => navigate('/cart')} sx={{ color: "#c1dbca" }}>
                                <Badge badgeContent={cartCount} color="error" max={99}>
                                    <ShoppingCartIcon />
                                </Badge>
                            </IconButton>
                        </Tooltip>

                        <Tooltip title="התנתקות">
                            <IconButton onClick={handleLogout} sx={{ color: "#c1dbca" }}>
                                <LogoutIcon />
                            </IconButton>
                        </Tooltip>
                    </Box>
                </Toolbar>
            </AppBar>

            <Container
                sx={{ flexGrow: 1, marginTop: '2rem', paddingLeft: '2rem', position: 'relative' }}
                maxWidth={false}
                disableGutters
            >
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/all-movies" element={<MovieListUser movies={moviesExemple} />} />
                    <Route path="/for-you" element={<ForYou />} />
                    <Route path="/cart" element={<Cart />} />
                    <Route path="/orders" element={<Orders />} />
                    <Route path="/about" element={<About />} />
                    {/* <Route path="/login" element={<Login />} /> */}
                    <Route path="/register" element={<Register />} />
                </Routes>

                <Collapse
                    in={isChatOpen}
                    sx={{
                        position: 'fixed',
                        bottom: 80,
                        right: 20,
                        width: 320,
                        boxShadow: 3,
                        borderRadius: 2,
                        backgroundColor: '#fff',
                        zIndex: 1300,
                    }}
                >
                    <Paper elevation={3} sx={{ p: 2, height: 400, display: 'flex', flexDirection: 'column' }}>
                        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 1 }}>
                            <Typography variant="h6">צ'אט</Typography>
                            <IconButton size="small" onClick={toggleChat}>
                                <CloseIcon />
                            </IconButton>
                        </Box>

                        <Box sx={{ flexGrow: 1, overflowY: 'auto', mb: 1, display: 'flex', flexDirection: 'column', gap: 1 }}>
                            {chatMessages.length === 0 ? (
                                <Typography variant="body2" color="text.secondary">
                                    ברוכים הבאים לצ'אט! איך אפשר לעזור?
                                </Typography>
                            ) : (
                                chatMessages.map((msg, idx) => (
                                    <Box key={idx} sx={{ backgroundColor: 'rgba(193, 219, 202, 0.5)', borderRadius: 1, p: 1 }}>
                                        <Typography variant="body2">{msg.text}</Typography>
                                        <Typography variant="caption" sx={{ textAlign: 'right', color: 'gray' }}>
                                            {msg.time}
                                        </Typography>
                                    </Box>
                                ))
                            )}
                        </Box>

                        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                            <TextField
                                variant="outlined"
                                fullWidth
                                placeholder="כתוב הודעה..."
                                value={newMessage}
                                onChange={(e) => setNewMessage(e.target.value)}
                                onKeyDown={(e) => {
                                    if (e.key === 'Enter' && newMessage.trim() !== '') {
                                        handleSendMessage();
                                    }
                                }}
                                sx={{
                                    '& .MuiOutlinedInput-root': {
                                        '& fieldset': {
                                            borderColor: '#c1dbca',
                                        },
                                        '&:hover fieldset': {
                                            borderColor: '#c1dbca',
                                        },
                                        '&.Mui-focused fieldset': {
                                            borderColor: '#75bba0',
                                        },
                                    },
                                }}
                            />
                            <IconButton
                                color="primary"
                                disabled={newMessage.trim() === ''}
                                onClick={handleSendMessage}
                                sx={{
                                    color: newMessage.trim() === '' ? 'gray' : '#c1dbca',
                                    '&:hover': {
                                        backgroundColor:
                                            newMessage.trim() === '' ? 'transparent' : 'rgba(193, 219, 202, 0.5)',
                                    },
                                }}
                            >
                                <SendIcon
                                    sx={{
                                        transform: 'rotate(180deg)',
                                        color: newMessage.trim() === '' ? 'gray' : '#c1dbca',
                                    }}
                                />
                            </IconButton>
                        </Box>
                    </Paper>
                </Collapse>
            </Container>

            <Box
                sx={{
                    flexShrink: 0,
                    textAlign: 'center',
                    padding: 2,
                    background: '#f5f5f5',
                    borderTop: '1px solid #ddd',
                }}
            >
                <Typography variant="body2" color="textSecondary">
                    All rights reserved &copy; 2025 | Movies for the Haredi Community | Developed by Programming Group 3 Seminar Beit Yaakov Bnot Elisheva
                </Typography>
            </Box>
        </Box>
    );
};

export default AppContent;
