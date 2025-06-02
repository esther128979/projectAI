import React, { useState } from 'react';
// import './SignUp.scss';
import axios from 'axios';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { loginUser } from '../../../redux/authSlice';

export function SignUp() {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError('');

        if (!username || !email || !password) {
            setError('All fields are required');
            return;
        }

        try {
            const response = await axios.post('https://localhost:7229/DosFlix/Users/register', {
                username,
                email,
                password,
            });

            const { token, username: name, role } = response.data;
            localStorage.setItem('token', token);
            dispatch(loginUser({ token, role, username: name }));

            navigate(role === 0 ? '/admin' : role === 1 ? '/manager' : '/user');
        } catch (err: any) {
            setError(err.response?.data || 'Registration failed');
        }
    };

    return (
        <div className="signup-page">
            <div className="signup-container">
                <h2>Create your account</h2>
                <form onSubmit={handleSubmit}>
                    {error && <p className="error">{error}</p>}

                    <label>Username</label>
                    <input
                        type="text"
                        placeholder="Enter a username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />

                    <label>Email</label>
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
                        placeholder="Enter a password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />

                    <button type="submit" className="sign-up-button">Sign up</button>
                </form>
            </div>
        </div>
    );
}
