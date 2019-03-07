<template>
    <div>
        <el-container style="width:80%; border: 1px solid #eee">
            <el-header>header</el-header>
            <el-main>main
                <router-view></router-view>
            </el-main>
        </el-container>
    </div>
</template>

<script>
export default {
    name: 'voteIndex',
    data () {
        return {

        }
    },
    methods: {
        
    },
}
</script>
