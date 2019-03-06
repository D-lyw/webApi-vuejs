<template>
    <div>
        <div class="demo-input-suffix">
        用户名：
        <el-input
            placeholder="请选择日期"
            suffix-icon="el-icon-date"
            v-model="username">
        </el-input>
        <br>
        密码：
        <el-input
            placeholder="请输入内容"
            prefix-icon="el-icon-search"
            v-model="password"
            type="password">
        </el-input>
        </div>
    </div>
</template>

<script>
export default {
    name: 'login',
    data () {
        return {
            username: '',
            password: ''
        }
    }
}
</script>
