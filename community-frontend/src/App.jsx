import { useEffect, useState } from "react";
import "./App.css";

export default function App() {
  const [communities, setCommunities] = useState([]);

  useEffect(() => {
    fetch("http://localhost:44441/api/communities")
      .then(res => res.json())
      .then(data => setCommunities(data));
  }, []);

  return (
    <div className="layout">
      {/* SIDEBAR */}
      <aside className="sidebar">
        <h2>Community</h2>

        <nav>
          <p>🏠 Home</p>
          <p>🔥 Trending</p>
          <p>⭐ Favorites</p>
          <p>⚙ Settings</p>
        </nav>
      </aside>

      {/* MAIN */}
      <main className="main">
        {/* TOPBAR */}
        <div className="topbar">
          <h1>Explore Communities</h1>
          <input placeholder="Search..." />
        </div>

        {/* GRID */}
        <div className="grid">
          {communities.map(c => (
            <div className="card" key={c.id}>
              <img src={c.iconUrl} alt="" />
              <h3>{c.communityName}</h3>
              <p>{c.numberOfMembers}</p>
              <button>Join</button>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
}