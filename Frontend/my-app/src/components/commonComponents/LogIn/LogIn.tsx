import React, { useState } from 'react';
import './LogIn.scss';
import { useNavigate } from 'react-router-dom';
import { useGoogleLogin } from '@react-oauth/google';
import axios from 'axios';
import { useDispatch } from 'react-redux';
import { loginUser } from '../../../redux/authSlice';


export function LogIn() {
    const dispatch = useDispatch();
    const navigate = useNavigate()
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError('');

        if (!email || !password) {
            setError('Both fields are required');
            return;
        }

        try {
            const response = await axios.post('http://localhost:5245/Controllers/UsersController/Login', {
                email,
                password,
            });

            const { email: userEmail, username, role } = response.data;

            dispatch(loginUser({
                role,
                username,
            }));

            // כאן אפשר לנווט לפי התפקיד אם רוצים
            if (role === 'admin') navigate('/admin')
            else navigate('/user')

        } catch (error) {
            setError('Invalid email or password');
            console.error(error);
        }
    };

    // const login = useGoogleLogin({
    //     onSuccess: async (tokenResponse) => {
    //         try {
    //             const res = await axios.get('https://www.googleapis.com/oauth2/v3/userinfo', {
    //                 headers: {
    //                     Authorization: `Bearer ${tokenResponse.access_token}`,
    //                 },
    //             });
    //             const userInfo = res.data;
    //             // בדוק אם המשתמש הוא מנהל
    //             if (userInfo.email === 'leah23531@gmail.com') {
    //                 dispatch(loginUser({
    //                     role: 'admin',
    //                     username: 'd'
    //                 }))
    //                 // navigate('admin')
    //             } else {
    //                 dispatch(loginUser({
    //      
    //                role: 'user',
    //                     username: 'd'
    //                 }))
    //                 // navigate('user')
    //             }

    //         } catch (err) {
    //             console.error('Failed to fetch user info:', err);
    //         }
    //     },
    //     onError: () => {
    //         console.error('Login Failed');
    //     },
    // });
    const login = useGoogleLogin({
        onSuccess: async (tokenResponse) => {
            try {
                const response = await axios.post('https://yourserver.com/api/auth/google-login', {
                    accessToken: tokenResponse.access_token,
                });

                // { email: string, username: string, role: string }
                const { email, username, role } = response.data;

                dispatch(loginUser({
                    role,
                    username,
                }));

                if (role === 'admin') navigate('/admin')
                else navigate('/user')

            } catch (err) {
                console.error('Failed to login with Google:', err);
                setError('Google login failed');
            }

        },
        onError: () => {
            setError('Google login failed');
        },
    });

    return (
        <div className="login-page">
            <div className="login-container">
                <img
                    className="logo"
                    src="https://ayeletginzburg.com/wp-content/uploads/2024/05/אייקון-פלאי-גדול-חלול-1024x1024.png"
                    alt="Logo"
                />
                <h2>Sign in to your account</h2>
                <p className="sub-text">
                    Not a member? <a href="#">Start a 14 day free trial</a>
                </p>
                <form onSubmit={handleSubmit}>
                    {error && <p className="error">{error}</p>}

                    <label>Email address</label>
                    <input
                        type="email"
                        placeholder="Enter your email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />

                    <label>Password</label>
                    <input
                        type="password"
                        placeholder="Enter your password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />

                    <div className="options">
                        <label>
                            <input type="checkbox" /> Remember me
                        </label>
                        <a href="#">Forgot password?</a>
                    </div>

                    <button type="submit" className="sign-in-button">Sign in</button>
                </form>

                <div className="divider">
                    <span>Or continue with</span>
                </div>

                <div className="social-buttons">
                    <button className="google-btn" onClick={() => login()}>
                        <img src="https://www.svgrepo.com/show/475656/google-color.svg" alt="Google" />
                        Google
                    </button>

                </div>
            </div>
        </div>
    );
};
