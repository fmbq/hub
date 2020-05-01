<template>
    <div>
        <h1>Login</h1>

        <form @submit.prevent="submit">
            <input type="text" v-model="email" placeholder="Email" />
            <input type="text" v-model="password" placeholder="Password" />

            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
import axios from "axios";

export default {
    metaInfo: {
        title: "Login"
    },

    data() {
        return {
            email: "",
            password: ""
        };
    },

    methods: {
        async submit(e) {
            try {
                await axios.post("/login", {
                    email: this.email,
                    password: this.password,
                });
            } catch (error) {
                console.log(error);
            }
        }
    }
};
</script>
