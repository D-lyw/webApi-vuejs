<template>
    <div id="main">
        <h2>- <span>用户注册</span> -</h2>
        <div class="demo-input-suffix">
            <label for="u">用户名：</label>
            <el-input
                id="u"
                placeholder="请输入用户名"
                suffix-icon = 'el-icon-edit'
                v-model="username"
                width="60%">
            </el-input>

        </div>
        <div class="demo-input-suffix">
            <label for="p">密码:</label>
            <el-input
                id="p"
                placeholder="请输入密码"
                suffix-icon="el-icon-edit"
                v-model="password"
                type="password">
            </el-input>
        </div>
        <br>
        <el-row>
            <el-button  type="success" round size="small">Register</el-button>
            <el-button plain round size="small" @click="GoToLogin"> go to login</el-button>
        </el-row>
    </div>
</template>

<script>
export default {
    name: 'register',
    data () {
        return {
            username: '',
            password: ''
        }
    },
    methods: {
        GoToLogin(){
            this.$router.push('/login');
        }
    },
}
</script>

<style scoped>
#main{
    width: 300px;
    top: 100px;
    padding: 30px 5%;
    margin: auto;
    border-radius: 6px;
    /* border: 1px solid grey; */
    box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04)
}
span{
    color: orangered;
}
label{
    text-align: left;
    padding: 3px;
    margin: 10px 0 3px;
    float: left;
}
</style>
